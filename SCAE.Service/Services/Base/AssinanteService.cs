using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SCAE.Data.Context;
using SCAE.Data.Interface.Base;
using SCAE.Data.Interface.Provider;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Shared;
using SCAE.Domain.Models.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Service.Interfaces.Almoxarifado;
using SCAE.Service.Interfaces.Base;
using SCAE.Service.Interfaces.Clientes;
using SCAE.Service.Interfaces.Empreendimento;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Base
{
    public class AssinanteService : CrudService<Assinante, IAssinanteRepository>, IAssinanteService
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IUsuarioService _usuarioService;
        private readonly IEmpresaService _empresaService;
        private readonly IAlmoxarifadoService _almoxarifadoService;
        private readonly IEmpreendimentoService _empreendimentoService;
        private readonly IFormaPagamentoService _formaPagamentoService;
        private readonly ITipoContratoService _tipoContratoService;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        private readonly IAssinanteRepository _assinanteRepository;

        private readonly IConfiguration _configuration;
        private readonly IOptions<BaseSettingModel> _baseSetting;


        public AssinanteService(IAssinanteRepository repository, IUsuarioService usuarioService, IDbContextFactory dbContextFactory,
            IEmpresaService empresaService, IAlmoxarifadoService almoxarifadoService, IEmpreendimentoService empreendimentoService,
            IFormaPagamentoService formaPagamentoService, ITipoContratoService tipoContratoService, ITipoDocumentoService tipoDocumentoService, IConfiguration configuration, IOptions<BaseSettingModel> baseSetting) : base(repository)
        {
            _usuarioService = usuarioService;
            _dbContextFactory = dbContextFactory;
            _empresaService = empresaService;
            _almoxarifadoService = almoxarifadoService;
            _empreendimentoService = empreendimentoService;
            _formaPagamentoService = formaPagamentoService;
            _tipoContratoService = tipoContratoService;
            _tipoDocumentoService = tipoDocumentoService;
            _assinanteRepository = repository;

            _configuration = configuration;
            _baseSetting = baseSetting;
        }

        public AssinanteService(IAssinanteRepository repository) : base(repository)
        {

        }

        public Assinante ObterAssinante(string host)
        {
            return _repository.ObterAssinante(host);
        }

        public override async Task Post(Assinante assinante)
        {
            if (assinante.Responsavel == null)
                throw new BadRequestException("Informe o responsável do assinante!");

            await base.Post(assinante);

            var context = _dbContextFactory.CreateDbContext(assinante);
            await context.Database.MigrateAsync();

            var empresa = new Empresa(assinante, assinante.Responsavel)
            {
                GerarZoop = assinante.GerarZoop,
                PessoaJuridica = true
            };

            _empresaService.ChangeContext(context);
            await _empresaService.Post(empresa);

            var empreendimento = new Domain.Entities.Empreendimento.Empreendimento()
            {
                EmpresaId = empresa.Id,
                Nome = assinante.Nome,
                Endereco = assinante.Endereco,
                TipoId = TipoEmpreendimento.Loteamento.Id,
                Legalizacao = new LegalizacaoEmpreendimento()
                {
                    Matricula = string.Empty,
                    EscrituraLavrada = string.Empty,
                    IncricaoCadastral = string.Empty,
                    LivroNumero = string.Empty,
                    NumeroProcesso = string.Empty,
                    Observacao = string.Empty,
                    OrgaoEmissor = string.Empty,
                    Rgi = string.Empty
                },
                Infraestrutura = new EmpreendimentoInfraestrutura()
                {
                    DimensaoLotePadrao = new DimensaoLote(),
                    Lazer = new InfraestruturaLazer()
                }
            };

            _empreendimentoService.ChangeContext(context);
            await _empreendimentoService.Post(empreendimento);

            var formaPagamento = new FormaPagamento()
            {
                EmpresaId = empresa.Id,
                Nome = "Boleto"
            };

            _formaPagamentoService.ChangeContext(context);
            await _formaPagamentoService.Post(formaPagamento);


            var tipoDocumento = new TipoDocumento()
            {
                EmpresaId = empresa.Id,
                Nome = "Boleto",
            };

            _tipoDocumentoService.ChangeContext(context);
            await _tipoDocumentoService.Post(tipoDocumento);

            var tipoContratoTerreno = new TipoContrato()
            {
                Nome = "Venda de Terreno",
                TipoOperacaoId = 1
            };

            var tipoContratoCasa = new TipoContrato()
            {
                Nome = "Venda de Casa",
                TipoOperacaoId = 1
            };

            _tipoContratoService.ChangeContext(context);
            await _tipoContratoService.Post(tipoContratoTerreno);
            await _tipoContratoService.Post(tipoContratoCasa);

            //var almoxarifado = new Domain.Entities.Almoxarifado.Almoxarifado
            //{
            //    EmpreendimentoId = empreendimento.Id,
            //    Nome = "CENTRAL"
            //};

            //_almoxarifadoService.ChangeContext(context);
            //await _almoxarifadoService.Post(almoxarifado);

            var usuario = new Usuario
            {
                AssinanteId = assinante.Id,
                Login = "master",
                Senha = "scae#scae*",
                Complementar =
                    {
                        Nome = "Master",
                        Email = "scae@scae.adm.br"//assinante.Email
                    },
                Permissoes = new Permissoes[]
                {
                        Permissoes.Master
                }
            };

            _usuarioService.ChangeContext(context);
            await _usuarioService.Post(usuario);
        }

        public override async Task Put(Assinante entity)
        {
            var assinante = await Get(entity.Id, "Dominios");

            if (assinante.Dominios.Any() && entity.Dominios.Any())
            {
                foreach (var dominio in assinante.Dominios)
                {
                    _assinanteRepository.DetachedDominio(dominio);
                    await _assinanteRepository.RemoveDominio(dominio.Id);
                }
            }

            await base.Put(entity);
        }

        public async Task<string> WhatsApp(int id)
        {
            var empresa = await _empresaService.Get(1);

            if (empresa == null)
                throw new NotFoundException("Empresa com id = 1 não encontrada");

            return empresa.Telefone1;
        }

        public async Task<ScaeApiContext> GetApiContext(int assinanteId)
        {
            var assinante = await Get(assinanteId);
            var options = new DbContextOptions<ScaeApiContext>();
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ScaeApiContext>(options);
            var apiContext = new ScaeApiContext(dbContextOptionsBuilder.Options, assinante, _configuration, _baseSetting);

            return apiContext;
        }
    }
}
