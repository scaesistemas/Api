using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Interface.Provider;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Shared
{
    public class AutenticadorService : IAutenticadorService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailService _emailService;
        private readonly IPessoaService _pessoaService;
        private readonly IAssinanteProvider _provider;
        private readonly IHttpContextAccessor _acessor;
        private readonly ApiKeysContainerModel _appSettings;

        public AutenticadorService(IConfiguration configuration, IUsuarioService usuarioService, IUsuarioRepository usuarioRepository,
            IEmailService emailService, IPessoaService pessoaService, IAssinanteProvider provider, IHttpContextAccessor acessor, IOptions<ApiKeysContainerModel> settings, IEmpresaService empresaService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _emailService = emailService;
            _pessoaService = pessoaService;
            _provider = provider;
            _acessor = acessor;
            _appSettings = settings.Value;
        }
        public string GenerateJwtToken(long id, string login, string nome, long assinanteId, string perfil, Permissoes[] permissoes)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Upn, id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, login),
                new Claim(ClaimTypes.Name, nome),
                new Claim(ClaimTypes.Role, perfil),
                new Claim("assinanteId", assinanteId.ToString()),
                new Claim("permissoes", JsonConvert.SerializeObject(permissoes)),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtExpireMinutes"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        } 
        public async Task<object> Autenticar(LoginModel model)
        {
            var assinante = _provider.GetTenant();

           // if (assinante.Ativo == false)
            //    throw new BadRequestException("Prezado cliente, sua plataforma está temporariamente bloqueada. Favor entrar em contato com a administradora.");

            var usuario = await _usuarioService.Login(model.Login, model.Senha);

            // verifica se é o login master
            var isMasterLogin = usuario.Login.Equals("master", StringComparison.OrdinalIgnoreCase);

            // verifica se tem a permissão 0
            var hasPermissaoMaster = usuario.Permissoes?.Any(p => p == 0) ?? false;

            var isMaster = isMasterLogin && hasPermissaoMaster;

            if (!isMaster && !assinante.Ativo)
                throw new BadRequestException("Prezado cliente, sua plataforma está temporariamente bloqueada. Favor entrar em contato com a administradora.");


            var usuarioFoto = await _usuarioService.CarregarFoto(usuario.Id);

            var retorno = new
            {
                Dados = new SessionAppModel(usuario.Id, usuario.Login, usuario.Complementar.Nome, usuario.AssinanteId, string.Empty, null)
                {
                    UsuarioFoto = usuarioFoto,
                    //EmpresaLogo = usuario.Empresa.Logo,
                    TemaEscuro = usuario.TemaEscuro,
                    Permissoes = usuario.Permissoes,

                },
                Token = GenerateJwtToken(usuario.Id, usuario.Login, usuario.Complementar.Nome, usuario.AssinanteId, "admin", usuario.Permissoes)
            };

            return retorno;
        }
        public async Task<object> AutenticarCliente(LoginModel model)
        {
            var assinante = _provider.GetTenant();
             
            if (assinante.Ativo == false)
                throw new BadRequestException("Prezado cliente, sua plataforma está temporariamente bloqueada. Favor entrar em contato com a administradora.");

            var usuario = await _usuarioService.Login(model.Login, model.Senha);
            var usuarioFoto = await _usuarioService.CarregarFoto(usuario.Id);

            if (usuario == null)
                throw new BadRequestException("Usuario não encontrado!");

            var pessoa = await _pessoaService.GetByUserId(usuario.Id);

            if (pessoa == null)
                throw new BadRequestException("Cliente não encontrado!");

            var retorno = new
            {
                Dados = new SessionAppModel(usuario.Id, usuario.Login, usuario.Complementar.Nome, usuario.AssinanteId, string.Empty, pessoa.Id)
                {
                    UsuarioFoto = usuarioFoto,
                    //EmpresaLogo = usuario.Empresa.Logo,
                    TemaEscuro = usuario.TemaEscuro,
                    Permissoes = usuario.Permissoes
                },
                Token = GenerateJwtToken(usuario.Id, usuario.Login, usuario.Complementar.Nome, usuario.AssinanteId, "cliente", usuario.Permissoes)
            };

            return retorno;
        }

        public async Task<object> AutenticarCorretor(LoginModel model)
        {
            var assinante = _provider.GetTenant();

            if (assinante.Ativo == false)
                throw new BadRequestException("Prezado cliente, sua plataforma está temporariamente bloqueada. Favor entrar em contato com a administradora.");

            var usuario = await _usuarioService.Login(model.Login, model.Senha);
            var usuarioFoto = await _usuarioService.CarregarFoto(usuario.Id);

            if (usuario == null)
                throw new BadRequestException("Corretor não encontrado!");

            var pessoa = await _pessoaService.GetByUserId(usuario.Id);

            if (pessoa == null || !pessoa.IsCorretor)
                throw new BadRequestException("Corretor não encontrado!");


            var retorno = new
            {
                Dados = new SessionAppModel(usuario.Id, usuario.Login, usuario.Complementar.Nome, usuario.AssinanteId, string.Empty, pessoa.Id)
                {
                    UsuarioFoto = usuarioFoto,
                    TemaEscuro = usuario.TemaEscuro,
                    Permissoes = usuario.Permissoes
                },
                Token = GenerateJwtToken(usuario.Id, usuario.Login, usuario.Complementar.Nome, usuario.AssinanteId, "cliente", usuario.Permissoes)
            };

            return retorno;
        }

        public async Task<object> AutenticarAdm(LoginModel model)
        {
            var usuario = await _usuarioService.Login(model.Login, model.Senha);
            var usuarioFoto = await _usuarioService.CarregarFoto(usuario.Id);

            var retorno = new
            {
                Dados = new SessionAppModel(usuario.Id, usuario.Login, usuario.Complementar.Nome, usuario.AssinanteId, string.Empty, null)
                {
                    UsuarioFoto = usuarioFoto,
                    //EmpresaLogo = usuario.Empresa.Logo,
                    TemaEscuro = usuario.TemaEscuro,
                    Permissoes = usuario.Permissoes,

                },
                Token = GenerateJwtToken(usuario.Id, usuario.Login, usuario.Complementar.Nome, usuario.AssinanteId, "admin", usuario.Permissoes)
            };

            return retorno;
        }

        public async Task<string> ConfirmaEmail(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new BadRequestException("Token não informado!");

            var usuario = await _usuarioRepository.GetAll().IgnoreQueryFilters().SingleOrDefaultAsync(x => x.Token == token);

            if (usuario == null)
                throw new BadRequestException(MensagemHelper.RegistroNaoEncontrato);

            if (!usuario.PrimeiroAcesso)
                throw new BadRequestException("E-mail já se encontra confirmado!");

            usuario.Token = null;
            usuario.PrimeiroAcesso = false;

            await _usuarioRepository.SaveChangesAsync();

            return "E-mail confirmado com sucesso!";
        }

        public async Task<string> ResetarSenha(string usuarioLogin, string token, string novaSenha)
        {

            if (string.IsNullOrEmpty(token) && string.IsNullOrEmpty(novaSenha))
            {
                if (string.IsNullOrEmpty(usuarioLogin))
                    throw new BadRequestException("Por favor informe o login do usuário!");

                var usuario = await _usuarioRepository.Login(usuarioLogin);

                if (usuario == null)
                    throw new NotFoundException("Usuario não encontrado!");

                var host = _provider.GetHost(_acessor, true);

                usuario = await _usuarioService.GetTrackingNoFilter(usuario.Id);
                usuario.Token = VerificaDisponibilidadeToken();

                await _emailService.EnviarEmail(
                    usuario.Complementar.Email,
                    "Recuperação de Senha",
                    _emailService.GerarCorpo(
                        usuario.Complementar.Nome,
                        $"Segue abaixo o link para redefinir sua senha! <br/> <a href='{host}login/resetSenha/{usuario.Token}'>Redefinir Senha</a>",
                        $"{DateTime.Now.Year} - SCAE"
                    )
                );

                await _usuarioService.SaveChangesAsync();

                return $"Email contendo a recuperação de senha enviado para: {usuario.Complementar.Email}";
            }
            else
            {
                var usuario = await _usuarioRepository.GetAll().IgnoreQueryFilters().SingleOrDefaultAsync(x => x.Token == token);

                if (usuario == null)
                    throw new NotFoundException("Usuario não encontrado!");

                if (usuario.Token != token || string.IsNullOrEmpty(token))
                    throw new BadRequestException("Token invalido!");

                if (string.IsNullOrEmpty(novaSenha))
                    throw new BadRequestException("Por favor, digite uma senha válida!");

                await _usuarioService.ResetarSenha(usuario.Id, novaSenha);

                return MensagemHelper.OperacaoSucesso;
            }
        }

        private string VerificaDisponibilidadeToken()
        {
            var token = UserTokenHelper.GenerateRandomPassword();

            var query = _usuarioRepository.GetAll().IgnoreQueryFilters().Any(x => x.Token == token);

            while (query)
            {
                token = UserTokenHelper.GenerateRandomPassword();
                query = _usuarioRepository.GetAll().IgnoreQueryFilters().Any(x => x.Token == token);
            }

            return token;
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = _configuration["JwtIssuer"],
                ValidAudience = _configuration["JwtIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"])) // The same key as the one that generate the token
            };
        }

        public bool AutenticarApiKey(string headerKey)
        {
            var apiKeys = _appSettings.ApiKeys.Where(x => x.Nome == headerKey);
            StringValues key = _acessor.HttpContext.Request.Headers[headerKey];
            int count = (from t in apiKeys where t.Chave == key select t).Count();
            return count == 0 ? false : true;
        }
    }
}
