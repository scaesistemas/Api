using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SCAE.Data.Context;
using SCAE.Data.Interface.Base;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Interface.Provider;
using SCAE.Domain.Entities.Geral;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Interfaces.Shared;
using SCAE.Service.Services.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Geral
{
    public class UsuarioService : CrudService<Usuario, IUsuarioRepository>, IUsuarioService
    {
        private readonly IAssinanteProvider _provider;
        private readonly IHttpContextAccessor _acessor;
        private readonly IEmailService _emailService;

        public UsuarioService(IUsuarioRepository repository, IAssinanteProvider provider, IHttpContextAccessor acessor, IEmailService emailService) : base(repository)
        {
            _provider = provider;
            _acessor = acessor;
            _emailService = emailService;
        }
        public UsuarioService(IUsuarioRepository repository, IAssinanteProvider provider, IHttpContextAccessor acessor) : base(repository)
        {
            _provider = provider;
            _acessor = acessor;
        }


        private Usuario GerarSenha(Usuario usuario)
        {
            var hasher = new PasswordHasher<Usuario>();
            usuario.Senha = hasher.HashPassword(usuario, usuario.GetSenha());

            return usuario;
        }

        private bool VerificaSenha(Usuario usuario, string senha)
        {
            var hasher = new PasswordHasher<Usuario>();

            return hasher.VerifyHashedPassword(usuario, usuario.GetSenha(), senha) != PasswordVerificationResult.Failed;
        }

        public async Task Post(Usuario usuario, string dominio)
        {
            usuario.Login = $"{usuario.Login}@{dominio}";

            await Post(usuario);
        }

        public async override Task Post(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.GetSenha()))
                throw new BadRequestException("Informe uma senha válida!");

            if (await _repository.LoginDuplicado(usuario.Login))
                throw new BadRequestException("Já existe um usuário com o mesmo login");

            if (string.IsNullOrEmpty(usuario.Complementar.Email))
                throw new BadRequestException("Campo obrigatório 'Email' não preenchido");

            if (!StringHelper.ValidarEmail(usuario.Complementar.Email))
                throw new BadRequestException("Formato de email inválido");


            usuario = GerarSenha(usuario);

            var getToken = UserTokenHelper.GenerateRandomPassword();

            usuario.Token = getToken;

            await base.Post(usuario);

            var host = _provider.GetHost(_acessor, true);

            await _emailService.EnviarEmail(
                usuario.Complementar.Email,
                "Verificação de E-mail",
                _emailService.GerarCorpo(
                    usuario.Complementar.Nome,
                    $"Sua senha de primeiro acesso são seus primeiros 6 digitos de CPF/CNPJ <br> Segue abaixo o link para verificação de e-mail! <br/> <a href='{host}login/{usuario.Token}'>Verificar E-mail</a> <br/>",
                    $"{DateTime.Now.Year} - SCAE"
                )
            );
        }

        public async override Task Put(Usuario usuario)
        {
            await base.Put(usuario);
        }

        public async Task AlterarSenha(int id, string senhaAntiga, string senhaNova)
        {
            var usuario = await Get(id);

            if (usuario == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            if (!VerificaSenha(usuario, senhaAntiga))
                throw new BadRequestException("Senha incorreta!");

            usuario.Senha = senhaNova;
            usuario = GerarSenha(usuario);

            await base.Put(usuario);
        }

        public async Task ResetarSenha(int id)
        {
            var usuario = await Get(id);

            if (usuario == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            usuario.Senha = "123@mudar";
            usuario = GerarSenha(usuario);

            await base.Put(usuario);
        }

        public async Task ResetarSenha(int id, string senhaNova)
        {
            var usuario = await GetTrackingNoFilter(id);

            if (usuario == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            usuario.Senha = senhaNova;
            usuario.Token = null;
            usuario = GerarSenha(usuario);

            await SaveChangesAsync();
        }

        public async Task<Usuario> Login(string login, string senha)
        {
            var usuario = await _repository.Login(login);

            var hasher = new PasswordHasher<Usuario>();

            if (hasher.VerifyHashedPassword(usuario, usuario?.GetSenha() ?? "", senha) != PasswordVerificationResult.Failed)
                return usuario;

            throw new BadRequestException("Login e/ou senha incorretos");
        }

        public async Task<bool> MudarTema(int id)
        {
            var usuario = await GetTracking(id);

            if (usuario == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            usuario.TemaEscuro = !usuario.TemaEscuro;

            await base.Put(usuario);

            return usuario.TemaEscuro;
        }

        public async Task<byte[]> CarregarFoto(int id)
        {
            var usuario = await GetTracking(id);

            if (usuario == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            return usuario.GetFoto();
        }


        public async Task SalvarPermissoes(int id, Permissoes[] permissoes)
        {
            var usuario = await GetTracking(id);

            if (usuario == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            usuario.Permissoes = permissoes;
            await SaveChangesAsync();
        }

        public async Task PermissoesPadraoAllUsuarios()
        {
            var usuarios = _repository.GetAll();
            foreach (var usuario in usuarios)
            {
                if (usuario.Permissoes == null)
                {
                    usuario.Permissoes = new Permissoes[] {
                        Permissoes.Financeiro_Receita_Agrupar,
                        Permissoes.Financeiro_Receita_Quitar,
                        Permissoes.Financeiro_Receita_VisualizarQuitacao,
                        Permissoes.Financeiro_Receita_VisualizarAntecipacao,
                        Permissoes.Financeiro_Receita_Antecipar,
                        Permissoes.Financeiro_Receita_GerarBoleto,
                        Permissoes.Financeiro_Receita_VisualizarEncargos,
                        Permissoes.Clientes_Contrato_Listar,
                        Permissoes.Clientes_Contrato_Cadastrar,
                        Permissoes.Clientes_Contrato_Alterar,
                        Permissoes.Financeiro_Receita_Listar,
                        Permissoes.Financeiro_Receita_ListarBaixa,
                        Permissoes.Financeiro_Receita_ListarParcela,
                        Permissoes.Financeiro_SituacaoReceitaParcela_Listar,
                        Permissoes.Financeiro_FormaPagamento_Listar,
                        Permissoes.Geral_Pessoa_Alterar,
                        Permissoes.Geral_Pessoa_Cadastrar,
                        Permissoes.Geral_Usuario_Alterar,
                        Permissoes.Geral_Pessoa_Listar,
                        Permissoes.Geral_TipoPessoa_Listar,
                        Permissoes.Geral_Sexo_Listar,
                        Permissoes.Geral_EstadoCivil_Listar,
                        Permissoes.Geral_Endereco_Listar,
                        Permissoes.Financeiro_SituacaoDespesaParcela_Listar,
                        Permissoes.Geral_Usuario_Alterar,
                        Permissoes.Geral_Usuario_AlterarSenha,
                        Permissoes.Geral_Usuario_Listar,
                        Permissoes.Geral_Usuario_MudarTema,
                        Permissoes.Geral_Usuario_ResetarSenha,
                        Permissoes.Financeiro_Relatorio_Listar
                    };
                }
            }
            await SaveChangesAsync();
        }

        public async Task AlterarMasterParaAdministrador(ScaeApiContext context)
        {
           ChangeContext(context);
           var usuarios = _repository.GetAll();
            var contadorUsuariosAlterados = 0;
           foreach (var usuario in usuarios)
            {
                var isMaster = usuario.Login == "master";
                if (isMaster)
                    continue;

                if (usuario.Login == "master1")
                {
                    usuario.Permissoes.Append(Permissoes.Master);
                    continue;
                }

                if (usuario.Permissoes != null && usuario.Permissoes.Any(x => x.Equals(Permissoes.Master)) && usuario.Login != "master1")
                {
                    usuario.Permissoes = usuario.Permissoes
                                                .Select(p => p == Permissoes.Master ? Permissoes.Administrador : p)
                                                .ToArray();
                    contadorUsuariosAlterados++;
                }
            }
            var _ = contadorUsuariosAlterados;
           await SaveChangesAsync();
        }
    }
}
