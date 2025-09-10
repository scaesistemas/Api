using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Interface.Provider;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Base;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Financeiro.ApiFinanceiro;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Geral
{
    public class PessoaService : CrudService<Pessoa, IPessoaRepository>, IPessoaService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAssinanteService _assinanteService;
        private readonly IAssinanteProvider _provider;
        private readonly IHttpContextAccessor _accessor;
        private readonly IDFourSignService _dFourSignService;
        private readonly IGatewayService _gatewayService;
        public PessoaService(IPessoaRepository repository, IUsuarioService usuarioService, IAssinanteService assinanteService, IAssinanteProvider provider, IHttpContextAccessor accessor, IDFourSignService dFourSignService, IGatewayService gatewayService) : base(repository)
        {
            _usuarioService = usuarioService;
            _assinanteService = assinanteService;
            _provider = provider;
            _accessor = accessor;
            _dFourSignService = dFourSignService;
            _gatewayService = gatewayService;
        }

        public async Task<List<Pessoa>> AutoComplete(string q, bool isCliente, bool isFornecedor, bool isCorretor, bool isProprietario, bool isSeguradora,
            bool isAdministradora, bool isConstrutora, bool isTransportadora)
        {
            return await _repository.AutoComplete(q, isCliente, isFornecedor, isCorretor, isProprietario, isSeguradora, isAdministradora, isConstrutora,
                isTransportadora);
        }

        public async Task<PessoaDocumento> AdicionarDocumento(int id, PessoaDocumento documento)
        {
            var pessoa = await _repository.GetByIdTrackingAsync(id, "Documentos");

            if (pessoa == null)
                throw new BadRequestException(MensagemHelper.RegistroNaoEncontrato);


            pessoa.Documentos.Add(documento);

            await SaveChangesAsync();

            return documento;
        }

        public async Task RemoverDocumento(int id, int documentoId)
        {
            var pessoa = await _repository.GetByIdTrackingAsync(id, "Documentos");

            if (pessoa == null)
                throw new BadRequestException(MensagemHelper.RegistroNaoEncontrato);

            var documentoExistente = pessoa.Documentos.FirstOrDefault(c => c.Id == documentoId);

            pessoa.Documentos.Remove(documentoExistente);
            await SaveChangesAsync();
        }

        public async Task<List<PessoaDocumento>> GetDocumentos(int pessoaId)
        {
            return await _repository.GetDocumentos(pessoaId);
        }

        public async Task<PessoaDocumento> GetDocumentoByIdAsync(int id)
        {
            return await _repository.GetDocumentoByIdAsync(id);
        }

        public override async Task Post(Pessoa entity)
        {

            if (Get().Any(x => x.CnpjCpf == entity.CnpjCpf))
                throw new BadRequestException("Já existe uma pessoa com esse CPF/CNPJ!");

            if (!CnpjCpfHelper.IsCPFCNPJValido(entity.CnpjCpf))
                throw new BadRequestException("CPF ou CNPJ inválido");


            await base.Post(entity);
        }

        public override async Task Put(Pessoa entity)
        {
            if (!CnpjCpfHelper.IsCPFCNPJValido(entity.CnpjCpf))
                throw new BadRequestException("CPF ou CNPJ inválido");

            await base.Put(entity);
        }

        public async override Task Patch(int id, JsonPatchDocument<Pessoa> model, string include)
        {
            var domain = string.IsNullOrEmpty(include) ? await GetTracking(id) : await GetTracking(id, include);

            if (domain == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            model.ApplyTo(domain);

            if (!CnpjCpfHelper.IsCPFCNPJValido(domain.CnpjCpf) && !domain.NaoValidarCPF)
                throw new BadRequestException("CPF ou CNPJ inválido");

            await SaveChangesAsync();

        }

        public async override Task Delete(int id)
        {
            var pessoa = await Get(id);

            if (!string.IsNullOrEmpty(pessoa.CodigoZoop))
                await _gatewayService.ExcluirPagador(EnumGateway.Zoop, pessoa.CodigoZoop);

            await base.Delete(pessoa);
        }

        public async Task<Pessoa> GetByUserId(int usuarioId)
        {
            return await _repository.GetByUserId(usuarioId);
        }

        public async Task CriarUsuario(string cpfCnpj)
        {
            using (var transaction = _repository.BeginTransaction())
            {
                var pessoa = await _repository.GetAll().IgnoreQueryFilters().SingleOrDefaultAsync(x => x.CnpjCpf == cpfCnpj);

                if (pessoa == null)
                    throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

                var host = _provider.GetHost(_accessor, false);

                var assinante = _assinanteService.ObterAssinante(host);

                var usuario = new Usuario()
                {
                    Login = pessoa.CnpjCpf,
                    Senha = pessoa.CpfCnpjLimpo.Substring(0, 6),
                    AssinanteId = assinante.Id,
                    Complementar = new Contato()
                    {
                        Nome = pessoa.Nome,
                        Celular = pessoa.Telefone,
                        Telefone = pessoa.Telefone,
                        Email = pessoa.Email
                    },
                    Permissoes = new Permissoes[] {
                        Permissoes.Financeiro_Receita_Agrupar,
                        Permissoes.Financeiro_Receita_Quitar,
                        Permissoes.Financeiro_Receita_VisualizarQuitacao,
                        Permissoes.Financeiro_Receita_VisualizarAntecipacao,
                        Permissoes.Financeiro_Receita_Antecipar,
                        Permissoes.Financeiro_Receita_GerarBoleto,
                        Permissoes.Financeiro_Receita_VisualizarEncargos,
                        Permissoes.Clientes_Contrato_Listar,
                        Permissoes.Financeiro_Receita_Listar,
                        Permissoes.Financeiro_Receita_ListarBaixa,
                        Permissoes.Financeiro_Receita_ListarParcela,
                        Permissoes.Financeiro_SituacaoReceitaParcela_Listar,
                        Permissoes.Financeiro_FormaPagamento_Listar,
                        Permissoes.Geral_Pessoa_Alterar,
                        Permissoes.Geral_Usuario_Alterar,
                        Permissoes.Geral_Pessoa_Listar,
                        Permissoes.Geral_TipoPessoa_Listar,
                        Permissoes.Geral_EstadoCivil_Listar,
                        Permissoes.Geral_Endereco_Listar,
                        Permissoes.Financeiro_SituacaoDespesaParcela_Listar,
                        Permissoes.Geral_Usuario_Alterar,
                        Permissoes.Geral_Usuario_AlterarSenha,
                        Permissoes.Geral_Usuario_Listar,
                        Permissoes.Geral_Usuario_MudarTema,
                        Permissoes.Geral_Usuario_ResetarSenha,
                        Permissoes.Financeiro_Relatorio_Listar
                    }

                };

                await _usuarioService.Post(usuario);

                pessoa.UsuarioId = usuario.Id;

                await SaveChangesAsync();

                transaction.Commit();
            }
        }

        public async Task<Pessoa> GetByCPF(string cpf, string include = "")
        {
            return await _repository.GetByCPF(cpf, include);
        }
        public async Task ExcluirPessoas()
        {
            var clientes = await _repository.GetAll().ToListAsync();

            foreach (var cliente in clientes)
            {
                _repository.Remove(cliente);
            }
            await SaveChangesAsync();
        }

        public async Task PostList(List<Pessoa> list, bool saveChanges = true)
        {
            await _repository.InsertList(list);

            if (saveChanges)
                await SaveChangesAsync();
        }
    }
}
