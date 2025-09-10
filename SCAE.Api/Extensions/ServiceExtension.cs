using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using SCAE.Api.Providers;
using SCAE.Data.Interface.Almoxarifado;
using SCAE.Data.Interface.Base;
using SCAE.Data.Interface.Clientes;
using SCAE.Data.Interface.Clientes.ContratoDigitalNS;
using SCAE.Data.Interface.Compras;
using SCAE.Data.Interface.ControleAgua;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Interface.Financeiro.PlanoDePagamento;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Interface.Projeto;
using SCAE.Data.Interface.Provider;
using SCAE.Data.Repository.Almoxarifado;
using SCAE.Data.Repository.Base;
using SCAE.Data.Repository.Clientes;
using SCAE.Data.Repository.Clientes.ContratoDigitalNS;
using SCAE.Data.Repository.Compras;
using SCAE.Data.Repository.ControleAgua;
using SCAE.Data.Repository.Empreendimento;
using SCAE.Data.Repository.Financeiro;
using SCAE.Data.Repository.Financeiro.PlanoDePagamento;
using SCAE.Data.Repository.Geral;
using SCAE.Data.Repository.Geral.CRMVendas;
using SCAE.Data.Repository.Geral.ModuloPrefeitura;
using SCAE.Data.Repository.OrcamentoObras;
using SCAE.Data.Repository.Projeto;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using SCAE.Repository.Interface.Financeiro;
using SCAE.Repository.Repository.Financeiro;
using SCAE.Service.Interfaces.Almoxarifado;
using SCAE.Service.Interfaces.Base;
using SCAE.Service.Interfaces.Clientes;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Compras;
using SCAE.Service.Interfaces.ControleAgua;
using SCAE.Service.Interfaces.Development;
using SCAE.Service.Interfaces.Empreendimento;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Financeiro.ApiFinanceiro;
using SCAE.Service.Interfaces.Financeiro.Gateway;
using SCAE.Service.Interfaces.Financeiro.PlanoDePagamento;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Interfaces.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral.ModuloPrefeitura;
using SCAE.Service.Interfaces.OrcamentoObras;
using SCAE.Service.Interfaces.Projeto;
using SCAE.Service.Interfaces.S3Service;
using SCAE.Service.Interfaces.Shared;
using SCAE.Service.Services.Almoxarifado;
using SCAE.Service.Services.Base;
using SCAE.Service.Services.Clientes;
using SCAE.Service.Services.Clientes.ContratoDigitalNS;
using SCAE.Service.Services.Compras;
using SCAE.Service.Services.ControleAgua;
using SCAE.Service.Services.Development;
using SCAE.Service.Services.Empreendimento;
using SCAE.Service.Services.Financeiro;
using SCAE.Service.Services.Financeiro.ApiFinanceiro;
using SCAE.Service.Services.Financeiro.Gateway;
using SCAE.Service.Services.Financeiro.PlanoDePagamento;
using SCAE.Service.Services.Geral;
using SCAE.Service.Services.Geral.CRMVendas;
using SCAE.Service.Services.Geral.ModuloPrefeitura;
using SCAE.Service.Services.OrcamentoObras;
using SCAE.Service.Services.Projeto;
using SCAE.Service.Services.Shared;
using SCAE.Service.Services.Storage;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SCAE.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IAssinanteProvider, AssinanteProvider>();
            services.AddScoped<IScaeApiContextFactory, ScaeApiContextFactory>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IDbContextFactory, DbContextFactory>();

            services.AddTransient<IAutenticadorService, AutenticadorService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IWhatsappService, WhatsappService>();
            services.AddTransient<ILoggerService, LoggerService>();

            #region Base

            services.AddTransient<IAssinanteRepository, AssinanteRepository>();
            services.AddTransient<IAssinanteService, AssinanteService>();
            services.AddTransient<ITermosDeUsoRepository, TermosDeUsoRepository>();
            services.AddTransient<ITermosDeUsoService, TermosDeUsoService>();
            services.AddTransient<ITipoTermoEmpresaRepository, TipoTermoEmpresaRepository>();
            services.AddTransient<ITipoTermoEmpresaService, TipoTermoEmpresaService>();

            services.AddTransient<IAdiantamentoCarteiraRepository, AdiantamentoCarteiraRepository>();
            services.AddTransient<IAdiantamentoCarteiraService, AdiantamentoCarteiraService>();

            services.AddTransient<ITipoAdiantamentoCarteiraRepository, TipoEmprestimoRepository>();
            services.AddTransient<ITipoAdiantamentoCarteiraService, TipoAdiantamentoCarteiraService>();

            services.AddTransient<ISituacaoAdiantamentoCarteiraRepository, SituacaoAdiantamentoCarteiraRepository>();
            services.AddTransient<ISituacaoAdiantamentoCarteiraService, SituacaoAdiantamentoCarteiraService>();

            services.AddTransient<IIndiceBaseRepository, IndiceBaseRepository>();
            services.AddTransient<IIndiceBaseService, IndiceBaseService>();

            services.AddTransient<ITipoIndiceBaseRepository, TipoIndiceBaseRepository>();
            services.AddTransient<ITipoIndiceBaseService, TipoIndiceBaseService>();

            #endregion

            #region Almoxarifado

            services.AddTransient<IGrupoProdutoRepository, GrupoProdutoRepository>();
            services.AddTransient<IGrupoProdutoService, GrupoProdutoService>();

            services.AddTransient<IAlmoxarifadoRepository, AlmoxarifadoRepository>();
            services.AddTransient<IAlmoxarifadoService, AlmoxarifadoService>();

            services.AddTransient<IInventarioRepository, InventarioRepository>();
            services.AddTransient<IInventarioService, InventarioService>();

            services.AddTransient<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddTransient<IMovimentacaoService, MovimentacaoService>();

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IProdutoService, ProdutoService>();

            services.AddTransient<IRequisicaoRepository, RequisicaoRepository>();
            services.AddTransient<IRequisicaoService, RequisicaoService>();

            services.AddTransient<ITipoMovimentacaoRepository, TipoMovimentacaoRepository>();
            services.AddTransient<ITipoMovimentacaoService, TipoMovimentacaoService>();

            services.AddTransient<ITipoProdutoRepository, TipoProdutoRepository>();
            services.AddTransient<ITipoProdutoService, TipoProdutoService>();

            services.AddTransient<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
            services.AddTransient<IUnidadeMedidaService, UnidadeMedidaService>();

            #endregion

            #region Clientes

            services.AddTransient<IContratoRepository, ContratoRepository>();
            services.AddTransient<IContratoService, ContratoService>();

            services.AddTransient<ITipoContratoRepository, TipoContratoRepository>();
            services.AddTransient<ITipoContratoService, TipoContratoService>();

            services.AddTransient<ITipoOperacaoContratoRepository, TipoOperacaoContratoRepository>();
            services.AddTransient<ITipoOperacaoContratoService, TipoOperacaoContratoService>();

            services.AddTransient<ITipoProdutoContratoRepository, TipoProdutoContratoRepository>();
            services.AddTransient<ITipoProdutoContratoService, TipoProdutoContratoService>();

            services.AddTransient<ITipoAditamentoContratoRepository, TipoAditamentoContratoRepository>();
            services.AddTransient<ITipoAditamentoContratoService, TipoAditamentoContratoService>();

            services.AddTransient<ISituacaoContratoRepository, SituacaoContratoRepository>();
            services.AddTransient<ISituacaoContratoService, SituacaoContratoService>();

            services.AddTransient<IModeloContratoDigitalService, ModeloContratoDigitalService>();
            services.AddTransient<IModeloContratoDigitalRepository, ModeloContratoDigitalRepository>();

            services.AddTransient<ISituacaoContratoDigitalService, SituacaoContratoDigitalService>();
            services.AddTransient<ISituacaoContratoDigitalRepository, SituacaoContratoDigitalRepository>();

            services.AddTransient<ITipoContratoDigitalService, TipoContratoDigitalService>();
            services.AddTransient<ITipoContratoDigitalRepository, TipoContratoDigitalRepository>();

            services.AddTransient<ISituacaoEmailSignatarioService, SituacaoEmailSignatarioService>();
            services.AddTransient<ISituacaoEmailSignatarioRepository, SituacaoEmailSignatarioRepository>();

            services.AddTransient<IDFourSignService, DFourSignService>();

            services.AddTransient<ITipoAssinaturaService, TipoAssinaturaService>();
            services.AddTransient<ITipoAssinaturaRepository, TipoAssinaturaRepository>();

            #endregion

            #region Compras

            services.AddTransient<IOrcamentoRepository, OrcamentoRepository>();
            services.AddTransient<IOrcamentoService, OrcamentoService>();

            services.AddTransient<ISituacaoOrcamentoRepository, SituacaoOrcamentoRepository>();
            services.AddTransient<ISituacaoOrcamentoService, SituacaoOrcamentoService>();

            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IPedidoService, PedidoService>();

            services.AddTransient<ISituacaoPedidoRepository, SituacaoPedidoRepository>();
            services.AddTransient<ISituacaoPedidoService, SituacaoPedidoService>();

            services.AddTransient<ISituacaoPedidoItemRepository, SituacaoPedidoItemRepository>();
            services.AddTransient<ISituacaoPedidoItemService, SituacaoPedidoItemService>();

            services.AddTransient<Data.Interface.Compras.IParametroRepository, Data.Repository.Compras.ParametroRepository>();
            services.AddTransient<Service.Interfaces.Compras.IParametroService, Service.Services.Compras.ParametroService>();

            #endregion

            #region Empreendimento

            services.AddTransient<IEmpreendimentoRepository, EmpreendimentoRepository>();
            services.AddTransient<IEmpreendimentoService, EmpreendimentoService>();

            services.AddTransient<ISituacaoUnidadeRepository, SituacaoUnidadeRepository>();
            services.AddTransient<ISituacaoUnidadeService, SituacaoUnidadeService>();

            services.AddTransient<ITipoEmpreendimentoRepository, TipoEmpreendimentoRepository>();
            services.AddTransient<ITipoEmpreendimentoService, TipoEmpreendimentoService>();

            services.AddTransient<ITipoGrupoRepository, TipoGrupoRepository>();
            services.AddTransient<ITipoGrupoService, TipoGrupoService>();

            services.AddTransient<ITipoImovelRepository, TipoImovelRepository>();
            services.AddTransient<ITipoImovelService, TipoImovelService>();

            services.AddTransient<ITipoUnidadeRepository, TipoUnidadeRepository>();
            services.AddTransient<ITipoUnidadeService, TipoUnidadeService>();

            services.AddTransient<IVicioRepository, VicioRepository>();
            services.AddTransient<IVicioService, VicioService>();

            #endregion

            #region Financeiro

            services.AddTransient<IZoopService, ZoopService>();
            services.AddTransient<ISafraService, SafraService>();

            services.AddTransient<IGalaxPayService, GalaxPayService>();

            services.AddTransient<IBancoRepository, BancoRepository>();
            services.AddTransient<Service.Interfaces.Financeiro.IBancoService, Service.Services.Financeiro.BancoService>();

            services.AddTransient<ICondicaoPagamentoRepository, CondicaoPagamentoRepository>();
            services.AddTransient<ICondicaoPagamentoService, CondicaoPagamentoService>();

            services.AddTransient<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddTransient<IContaCorrenteService, ContaCorrenteService>();

            services.AddTransient<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddTransient<IFormaPagamentoService, FormaPagamentoService>();

            services.AddTransient<IIndiceRepository, IndiceRepository>();
            services.AddTransient<IIndiceService, IndiceService>();

            services.AddTransient<ISituacaoDespesaParcelaRepository, SituacaoDespesaParcelaRepository>();
            services.AddTransient<ISituacaoDespesaParcelaService, SituacaoDespesaParcelaService>();

            services.AddTransient<ISituacaoReceitaParcelaRepository, SituacaoReceitaParcelaRepository>();
            services.AddTransient<ISituacaoReceitaParcelaService, SituacaoReceitaParcelaService>();

            services.AddTransient<ITipoDespesaRepository, TipoDespesaRepository>();
            services.AddTransient<ITipoDespesaService, TipoDespesaService>();

            services.AddTransient<ITipoReceitaRepository, TipoReceitaRepository>();
            services.AddTransient<ITipoReceitaService, TipoReceitaService>();

            services.AddTransient<ITipoDocumentoRepository, TipoDocumentoRepository>();
            services.AddTransient<ITipoDocumentoService, TipoDocumentoService>();

            services.AddTransient<ITipoIndiceRepository, TipoIndiceRepository>();
            services.AddTransient<ITipoIndiceService, TipoIndiceService>();

            services.AddTransient<ICentroCustoRepository, CentroCustoRepository>();
            services.AddTransient<ICentroCustoService, CentroCustoService>();

            services.AddTransient<IContaGerencialRepository, ContaGerencialRepository>();
            services.AddTransient<IContaGerencialService, ContaGerencialService>();

            services.AddTransient<IDespesaRepository, DespesaRepository>();
            services.AddTransient<IDespesaService, DespesaService>();

            services.AddTransient<IReceitaRepository, ReceitaRepository>();
            services.AddTransient<IReceitaService, ReceitaService>();

            services.AddTransient<ITipoGatewayRepository, TipoGatewayRepository>();
            services.AddTransient<ITipoGatewayService, TipoGatewayService>();

            services.AddTransient<ILayoutCobrancaRepository, LayoutCobrancaRepository>();
            services.AddTransient<ILayoutCobrancaService, LayoutCobrancaService>();

            services.AddTransient<IRelatorioService, RelatorioService>();

            services.AddTransient<ITipoServicoParcelaRepository, TipoServicoParcelaRepository>();
            services.AddTransient<ITipoServicoParcelaService, TipoServicoParcelaService>();

            services.AddTransient<Data.Interface.Financeiro.IParametroRepository, Data.Repository.Financeiro.ParametroRepository>();
            services.AddTransient<Service.Interfaces.Financeiro.IParametroService, Service.Services.Financeiro.ParametroService>();

            services.AddTransient<IReguaCobrancaService, ReguaCobrancaService>();
            services.AddTransient<IReguaCobrancaRepository, ReguaCobrancaRepository>();

            services.AddTransient<ITipoAmortizacaoService, TipoAmortizacaoService>();
            services.AddTransient<ITipoAmortizacaoRepository, TipoAmortizacaoRepository>();

            services.AddTransient<IIntervaloReajusteService, IntervaloReajusteService>();
            services.AddTransient<IIntervaloReajusteRepository, IntervaloReajusteRepository>();

            services.AddTransient<ITipoAntecipacaoService, TipoAntecipacaoService>();
            services.AddTransient<ITipoAntecipacaoRepository, TipoAntecipacaoRepository>();

            services.AddTransient<IRetornoBancarioRepository, RetornoBancarioRepository>();
            services.AddTransient<IRetornoBancarioService, RetornoBancarioService>();

            services.AddTransient<IGatewayService, GatewayService>();

            services.AddTransient<IPlanoPagamentoService, PlanoPagamentoService>();
            services.AddTransient<IPlanoPagamentoRepository, PlanoPagamentoRepository>();

            services.AddTransient<ITipoMesReajusteService, TipoMesReajusteService>();
            services.AddTransient<ITipoMesReajusteRepository, TipoMesReajusteRepository>();

            services.AddTransient<ITipoPlanoPagamentoService, TipoPlanoPagamentoService>();
            services.AddTransient<ITipoPlanoPagamentoRepository, TipoPlanoPagamentoRepository>();

            services.AddTransient<ITipoAnoInicioReajusteService, TipoAnoInicioReajusteService>();
            services.AddTransient<ITipoAnoInicioReajusteRepository, TipoAnoInicioReajusteRepository>();

            services.AddTransient<ITipoIntervaloParcelaService, TipoIntervaloParcelaService>();
            services.AddTransient<ITipoIntervaloParcelaRepository, TipoIntervaloParcelaRepository>();

            services.AddTransient<ITipoRemessaService, TipoRemessaService>();
            services.AddTransient<ITipoRemessaRepository, TipoRemessaRepository>();

            services.AddTransient<IRemessaService, RemessaService>();
            services.AddTransient<IRemessaRepository, RemessaRepository>();

            services.AddTransient<ITipoOperacaoFinanceiraService, TipoOperacaoFinanceiraService>();
            services.AddTransient<ITipoOperacaoFinanceiraRepository, TipoOperacaoFinanceiraRepository>();

            services.AddTransient<IBoletoService, BoletoService>();
            services.AddTransient<IApiFinanceiroBaseService, ApiFinanceiroBaseService>();

            services.AddTransient<ITipoListaBancoService, TipoListaBancoService>();
            services.AddTransient<ITipoListaBancoRepository, TipoListaBancoRepository>();



            #endregion

            #region Geral

            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<IPessoaService, PessoaService>();

            services.AddTransient<ICartorioRepository, CartorioRepository>();
            services.AddTransient<ICartorioService, CartorioService>();

            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IEmpresaService, EmpresaService>();

            services.AddTransient<IEstadoRepository, EstadoRepository>();
            services.AddTransient<IMunicipioRepository, MunicipioRepository>();
            services.AddTransient<IEnderecoService, EnderecoService>();

            services.AddTransient<IEstadoCivilRepository, EstadoCivilRepository>();
            services.AddTransient<IEstadoCivilService, EstadoCivilService>();

            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<ILogService, LogService>();

            services.AddTransient<INacionalidadeRepository, NacionalidadeRepository>();
            services.AddTransient<INacionalidadeService, NacionalidadeService>();

            services.AddTransient<IProfissaoRepository, ProfissaoRepository>();
            services.AddTransient<IProfissaoService, ProfissaoService>();

            services.AddTransient<ISeguradoraRepository, SeguradoraRepository>();
            services.AddTransient<ISeguradoraService, SeguradoraService>();

            services.AddTransient<ISexoRepository, SexoRepository>();
            services.AddTransient<ISexoService, SexoService>();

            services.AddTransient<ISituacaoFreteRepository, SituacaoFreteRepository>();
            services.AddTransient<ISituacaoFreteService, SituacaoFreteService>();

            services.AddTransient<ITipoOrigemRepository, TipoOrigemRepository>();
            services.AddTransient<ITipoOrigemService, TipoOrigemService>();

            services.AddTransient<ITipoPessoaRepository, TipoPessoaRepository>();
            services.AddTransient<ITipoPessoaService, TipoPessoaService>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddTransient<ITipoProcessoJudicialRepository, TipoProcessoJudicialRepository>();
            services.AddTransient<ITipoProcessoJudicialService, TipoProcessoJudicialService>();


            services.AddTransient<ITipoEmpresaRepository, TipoEmpresaRepository>();
            services.AddTransient<ITipoEmpresaService, TipoEmpresaService>();

            services.AddTransient<ITipoEscolaridadeRepository, TipoEscolaridadeRepository>();
            services.AddTransient<ITipoEscolaridadeService, TipoEscolaridadeService>();

            services.AddTransient<IOfxParserService, OfxParserService>();

            services.AddTransient<IPessoaPrefeituraRepository, PessoaPrefeituraRepository>();
            services.AddTransient<IPessoaPrefeituraService, PessoaPrefeituraService>();

            services.AddTransient<ITipoColetaLixoRepository, TipoColetaLixoRepository>();
            services.AddTransient<ITipoColetaLixoService, TipoColetaLixoService>();

            services.AddTransient<ITipoAbastecimentoAguaRepository, TipoAbastecimentoAguaRepository>();
            services.AddTransient<ITipoAbastecimentoAguaService, TipoAbastecimentoAguaService>();

            services.AddTransient<ITipoEnergiaMoradiaRepository, TipoEnergiaMoradiaRepository>();
            services.AddTransient<ITipoEnergiaMoradiaService, TipoEnergiaMoradiaService>();

            services.AddTransient<ITipoMoradiaRepository, TipoMoradiaRepository>();
            services.AddTransient<ITipoMoradiaService, TipoMoradiaService>();

            services.AddTransient<ITipoMoradiaNovaRepository, TipoMoradiaNovaRepository>();
            services.AddTransient<ITipoMoradiaNovaService, TipoMoradiaNovaService>();

            services.AddTransient<ITipoEsgotamentoSanitarioRepository, TipoEsgotamentoSanitarioRepository>();
            services.AddTransient<ITipoEsgotamentoSanitarioService, TipoEsgotamentoSanitarioService>();

            services.AddTransient<ITipoCondicaoMoradiaRepository, TipoCondicaoMoradiaRepository>();
            services.AddTransient<ITipoCondicaoMoradiaService, TipoCondicaoMoradiaService>();

            services.AddTransient<ITipoEdificacaoMoradiaRepository, TipoEdificacaoMoradiaRepository>();
            services.AddTransient<ITipoEdificacaoMoradiaService, TipoEdificacaoMoradiaService>();

            services.AddTransient<IPWhitelistAttributeService>();


            #endregion

            #region Projeto

            services.AddTransient<IContratoFornecedorService, ContratoFornecedorService>();
            services.AddTransient<IContratoFornecedorRepository, ContratoFornecedorRepository>();

            services.AddTransient<IOrcadoRepository, OrcadoRepository>();
            services.AddTransient<IOrcadoService, OrcadoService>();

            services.AddTransient<IEtapaRepository, EtapaRepository>();
            services.AddTransient<IEtapaService, EtapaService>();

            services.AddTransient<IMedicaoRepository, MedicaoRepository>();
            services.AddTransient<IMedicaoService, MedicaoService>();

            services.AddTransient<ITipoContratoFornecedorRepository, TipoContratoFornecedorRepository>();
            services.AddTransient<ITipoContratoFornecedorService, TipoContratoFornecedorService>();

            #endregion

            #region OrcamentoObras

            services.AddTransient<IClasseComposicaoRepository, ClasseComposicaoRepository>();
            services.AddTransient<IClasseComposicaoService, ClasseComposicaoService>();

            services.AddTransient<IComposicaoRepository, ComposicaoRepository>();
            services.AddTransient<IComposicaoService, ComposicaoService>();

            services.AddTransient<IComposicaoItemRepository, ComposicaoItemRepository>();
            services.AddTransient<IComposicaoItemService, ComposicaoItemService>();

            services.AddTransient<IOrcamentoEtapaRepository, OrcamentoEtapaRepository>();
            services.AddTransient<IOrcamentoEtapaService, OrcamentoEtapaService>();

            services.AddTransient<IOrcamentoEtapaItemRepository, OrcamentoEtapaItemRepository>();
            services.AddTransient<IOrcamentoEtapaItemService, OrcamentoEtapaItemService>();

            services.AddTransient<IOrcamentoObrasRepository, OrcamentoObrasRepository>();
            services.AddTransient<IOrcamentoObrasService, OrcamentoObrasService>();

            services.AddTransient<IOrigemDadosRepository, OrigemDadosRepository>();
            services.AddTransient<IOrigemDadosService, OrigemDadosService>();

            services.AddTransient<ITipoComposicaoRepository, TipoComposicaoRepository>();
            services.AddTransient<ITipoComposicaoService, TipoComposicaoService>();

            services.AddTransient<ITipoInsumoRepository, TipoInsumoRepository>();
            services.AddTransient<ITipoInsumoService, TipoInsumoService>();

            services.AddTransient<IInsumoRepository, InsumoRepository>();
            services.AddTransient<IInsumoService, InsumoService>();

            services.AddTransient<IModeloOrcamentoEtapaRepository, ModeloOrcamentoEtapaRepository>();
            services.AddTransient<IModeloOrcamentoEtapaService, ModeloOrcamentoEtapaService>();

            #endregion

            #region AreaCorretor

            services.AddTransient<IReservaRepository, ReservaRepository>();
            services.AddTransient<IReservaService, ReservaService>();

            services.AddTransient<ILeadRepository, LeadRepository>();
            services.AddTransient<ILeadService, LeadService>();

            services.AddTransient<IGrauParentescoRepository, GrauParentescoRepository>();
            services.AddTransient<IGrauParentescoService, GrauParentescoService>();

            services.AddTransient<ITipoReservaRepository, TipoReservaRepository>();
            services.AddTransient<ITipoReservaService, TipoReservaService>();

            services.AddTransient<ISituacaoReservaRepository, SituacaoReservaRepository>();
            services.AddTransient<ISituacaoReservaService, SituacaoReservaService>();

            services.AddTransient<IReservaObservacaoRepository, ReservaObservacaoRepository>();
            services.AddTransient<IReservaObservacaoService, ReservaObservacaoService>();

            services.AddTransient<IGrauInteresseRepository, GrauInteresseRepository>();
            services.AddTransient<IGrauInteresseService, GrauInteresseService>();

            services.AddTransient<ITipoAtendimentoRepository, TipoAtendimentoRepository>();
            services.AddTransient<ITipoAtendimentoService, TipoAtendimentoService>();

            services.AddTransient<IAtendimentoRepository, AtendimentoRepository>();
            services.AddTransient<IAtendimentoService, AtendimentoService>();

            services.AddTransient<IColunaFunilRepository, ColunaFunilRepository>();
            services.AddTransient<IColunaFunilService, ColunaFunilService>();

            services.AddTransient<IComoLeadContactouService, ComoLeadContactouService>();
            services.AddTransient<IComoLeadContactouRepository, ComoLeadContactouRepository>();

            services.AddTransient<IComoLeadNosEncontrouService, ComoLeadNosEncontrouService>();
            services.AddTransient<IComoLeadNosEncontrouRepository, ComoLeadNosEncontrouRepository>();

            services.AddTransient<IMotivoCancelamentoReservaService, MotivoCancelamentoReservaService>();
            services.AddTransient<IMotivoCancelamentoReservaRepository, MotivoCancelamentoReservaRepository>();

            #endregion

            #region ControleAgua
            services.AddTransient<IHidrometroRepository, HidrometroRepository>();
            services.AddTransient<IHidrometroService, HidrometroService>();

            services.AddTransient<IMarcacaoAguaRepository, MarcacaoAguaRepository>();
            services.AddTransient<IMarcacaoAguaService, MarcacaoAguaService>();

            services.AddTransient<IQualidadeAguaRepository, QualidadeAguaRepository>();
            services.AddTransient<IQualidadeAguaService, QualidadeAguaService>();

            services.AddTransient<ITabelaValorConsumoAguaRepository, TabelaValorConsumoAguaRepository>();
            services.AddTransient<ITabelaValorConsumoAguaService, TabelaValorConsumoAguaService>();
            #endregion

            services.AddTransient<IS3Service, S3Service>();

            #region Development

            services.AddTransient<IApiDevelopmentService, ApiDevelopmentService>();

            #endregion
        }

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["JwtIssuer"],
                    ValidAudience = configuration["JwtIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void EnsureMigrationsRun(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContextFactory = serviceScope.ServiceProvider.GetService<IDbContextFactory>();
                var allTenants = serviceScope.ServiceProvider.GetService<IAssinanteProvider>().AllTenants;

                foreach (var tenant in allTenants)
                {
                    var context = dbContextFactory.CreateDbContext(tenant);
                    context.Database.Migrate();
                }
            }
        }
    }
}
