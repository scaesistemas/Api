using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SCAE.Data.Extension;
using SCAE.Data.Interface.Provider;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Domain.Entities.ControleAgua;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Domain.Entities.Projeto;
using SCAE.Domain.Models.Shared;


namespace SCAE.Data.Context
{
    public class ScaeApiContext : DbContext
    {
        private readonly BaseSettingModel _baseSetting;
        private readonly string _stringConnection;
        private readonly string _dataBaseName;
        private readonly Assinante _assinante;
        public SessionAppModel SessionApp { get; }

        public ScaeApiContext()
        {

        }

        public ScaeApiContext(DbContextOptions<ScaeApiContext> options, Assinante assinante, IConfiguration configuration, IOptions<BaseSettingModel> baseSetting) : base(options)
        {
            _assinante = assinante;
            _baseSetting = baseSetting.Value;

            if (_assinante == null)
                _dataBaseName = "homologacao";
            else
                _dataBaseName = _assinante.SubDominio.ToLower();

            _stringConnection = string.Format(configuration.GetConnectionString("BasePrincipal"),
                _baseSetting.Host, _baseSetting.Port, _baseSetting.Pooling, _baseSetting.PrefixDatabase, _dataBaseName,
                _baseSetting.User, _baseSetting.Password);
        }

        public ScaeApiContext(DbContextOptions<ScaeApiContext> options, IConfiguration configuration, IOptions<BaseSettingModel> baseSetting, IAssinanteProvider tenantProvider) : base(options)
        {
            _assinante = tenantProvider.GetTenant();
            _baseSetting = baseSetting.Value;

            if (_assinante == null)
                _dataBaseName = "homologacao";
            else
                _dataBaseName = _assinante.SubDominio.ToLower();

            _stringConnection = string.Format(configuration.GetConnectionString("BasePrincipal"),
                _baseSetting.Host, _baseSetting.Port, _baseSetting.Pooling, _baseSetting.PrefixDatabase, _dataBaseName,
                _baseSetting.User, _baseSetting.Password);
        }

        #region Financeiro

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<ContaCorrente> ContaCorrentes { get; set; }
        public DbSet<ContaCorrenteGateway> contaCorrenteGateways { get; set; }
        public DbSet<ContaGerencial> ContaGerenciais { get; set; }
        public DbSet<CentroCusto> CentroCustos { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<CondicaoPagamento> CondicaoPagamentos { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<ReceitaParcela> ReceitaParcelas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<DespesaClassificacao> DespesaClassificacoes { get; set; }
        public DbSet<DespesaParcela> DespesaParcelas { get; set; }
        public DbSet<DespesaBaixa> DespesaBaixas { get; set; }
        public DbSet<Indice> Indices { get; set; }

        public DbSet<RetornoBancario> RetornosBancarios { get; set; }

        public DbSet<ReceitaBaixaComprovante> receitaBaixaComprovantes { get; set; }
        public DbSet<AntecipacaoComprovante> antecipacaoComprovantes { get; set; }
        public DbSet<Domain.Entities.Financeiro.Parametro> FinanceiroParametros { get; set; }
        public DbSet<ReguaCobranca> ReguaCobrancas { get; set; }

        public DbSet<TipoAmortizacao> TipoAmortizacoes { get; set; }
        public DbSet<TipoAntecipacao> tipoAntecipacoes { get; set; }
        public DbSet<IntervaloReajuste> IntervaloReajustes { get; set; }

        public DbSet<AntecipacaoAmortizacao> AntecipacaoAmortizacoes { get; set; }
        public DbSet<AntecipacaoAmortizacaoItem> AntecipacaoAmortizacaoItens { get; set; }
        public DbSet<ReceitaTransacao> ReceitaTransacoes { get; set; }
        public DbSet<TipoOperacaoFinanceira> TipoOperacaoFinanceiras { get; set; }

        public DbSet<TipoMesReajuste> InicioContagemReajustes { get; set; }
        public DbSet<TipoPlanoPagamento> TipoPlanoPagamentos { get; set; }
        public DbSet<PlanoPagamentoModelo> PlanoPagamentoModelos { get; set; }
        public DbSet<TipoIntervaloParcela> TipoIntervaloParcelas { get; set; }
        public DbSet<TipoListaBanco> TipoListaBancos { get; set; }
        public DbSet<TipoStatusTransacao> TipoStatusTransacoes { get; set; }
        public DbSet<Remessa> Remessas { get; set; }


        //public DbSet<TipoDespesa> TipoDespesas { get; set; }
        //public DbSet<SituacaoDespesaParcela> SituacaoDespesaParcelas { get; set; }
        //public DbSet<SituacaoReceitaParcela> SituacaoReceitaParcelas { get; set; }

        #endregion

        #region Almoxarifado
        public DbSet<Almoxarifado> Almoxarifados { get; set; }
        public DbSet<AlmoxarifadoItem> AlmoxarifadoItens { get; set; }
        public DbSet<GrupoProduto> GrupoProdutos { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }
        public DbSet<Requisicao> Requisicoes { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

        #endregion

        #region Loteamento
        public DbSet<Cartorio> Cartorios { get; set; }
        public DbSet<Empreendimento> Empreendimentos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Seguradora> Seguradoras { get; set; }
        public DbSet<LadoAdicional> LadosAdicionais { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipoReserva> TiposReservas { get; set; }
        public DbSet<SituacaoReserva> SituacaoReservas { get; set; }
        public DbSet<ReservaObservacao> ReservaObservacoes { get; set; }
        public DbSet<MotivoCancelamentoReserva> MotivosCancelamentoReservas { get; set; }


        #endregion

        #region Clientes
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<TipoContrato> TipoContratos { get; set; }
        public DbSet<ContratoDigital> ContratoDigitais { get; set; }
        public DbSet<ModeloContratoDigital> ModeloContratoDigitais { get; set; }
        public DbSet<SignatarioContratoDigital> SignatarioContratoDigitais { get; set; }
        public DbSet<SituacaoContratoDigital> SituacaoContratoDigitais { get; set; }
        public DbSet<SituacaoEmailSignatario> SituacaoEmailSignatarios { get; set; }
        public DbSet<TipoContratoDigital> TipoContratoDigitais { get; set; }
        public DbSet<TipoAssinatura> TipoAssinaturas { get; set; }


        #endregion

        #region Compras
        public DbSet<Domain.Entities.Compras.Parametro> ComprasParametros { get; set; }
        #endregion

        #region Geral
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EmpresaGateway> EmpresaGateways { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaGateway> PessoaGateways { get; set; }
        public DbSet<EmpreendimentoPessoa> EmpreendimentoPessoas { get; set; }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<TipoOrigem> TipoOrigens { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<TipoProcessoJudicial> TipoProcessoJudiciais { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<GrauInteresse> GrauInteresses { get; set; }
        public DbSet<GrauParentesco> GrauParentescos { get; set; }
        public DbSet<TipoEmpresa> TiposEmpresas { get; set; }
        public DbSet<ComoLeadContactou> ComoLeadContactou { get; set; }
        public DbSet<ComoLeadNosEncontrou> ComoLeadNosEncontrou { get; set; }


        #region Prefeitura
        public DbSet<PessoaPrefeitura> pessoaPrefeituras { get; set; }
        //public DbSet<Moradia> Moradias { get; set; }
        public DbSet<TipoMoradia> tipoMoradias { get; set; }
        public DbSet<TipoAbastecimentoAgua> TipoAbastecimentoAguas { get; set; }
        public DbSet<TipoEnergiaMoradia> TipoEnergiaMoradias { get; set; }
        public DbSet<TipoColetaLixo> TipoColetaLixos { get; set; }
        #endregion


        #endregion

        #region Projeto
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<Orcado> Orcados { get; set; }
        public DbSet<ContratoFornecedor> ContratoFornecedor { get; set; }
        public DbSet<Medicao> Medicoes { get; set; }
        public DbSet<Execucao> Execucoes { get; set; }

        #endregion

        #region OrcamentoObras

        public DbSet<ClasseComposicao> ClasseComposicoes { get; set; }
        public DbSet<Composicao> Composicoes { get; set; }
        //public DbSet<ComposicaoItem> ComposicaoItens { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<OrcamentoEtapa> OrcamentoEtapas { get; set; }
        public DbSet<OrcamentoEtapaItem> OrcamentoEtapaItens { get; set; }
        public DbSet<OrcamentoObras> OrcamentosObras { get; set; }
        public DbSet<OrigemDados> OrigensDados { get; set; }
        public DbSet<TipoComposicao> TiposComposicao { get; set; }
        public DbSet<TipoInsumo> TiposInsumo { get; set; }

        //Modelos
        public DbSet<ModeloOrcamentoEtapa> ModeloOrcamentoEtapa { get; set; }
        public DbSet<ModeloOrcamentoEtapaItem> ModeloOrcamentoEtapaItem { get; set; }

        #endregion

        #region ControleAgua
        public DbSet<Hidrometro> Hidrometros { get; set; }
        public DbSet<MarcacaoAgua> MarcacaoAguas { get; set; }
        public DbSet<QualidadeAgua> QualidadeAguas { get; set; }
        public DbSet<TabelaValorConsumoAgua> TabelaValorConsumoAguas { get; set; }
        public DbSet<TabelaValorConsumoAguaItem> TabelaValorConsumoAguaItems { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();

            modelBuilder.Entity<Empresa>().HasIndex(x => x.CpfCnpj).IsUnique();
            modelBuilder.Entity<Pessoa>().HasIndex(x => x.CnpjCpf).IsUnique();
            modelBuilder.Entity<Usuario>().OwnsOne(x => x.Complementar);
            modelBuilder.Entity<Domain.Entities.Financeiro.Parametro>().HasIndex(x => x.EmpresaId).IsUnique();
            modelBuilder.Entity<ParametroGatway>().OwnsOne(p => p.GalaxPay);

            modelBuilder.Entity<Receita>().HasOne(b => b.Tipo).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Receita>().HasOne(b => b.TipoDocumento).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Receita>().HasOne(b => b.Cliente).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Receita>().HasOne(b => b.Empresa).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Receita>().HasOne(b => b.Empreendimento).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Receita>().HasOne(b => b.Contrato).WithMany(x => x.Receitas).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Despesa>().HasOne(b => b.Tipo).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Despesa>().HasOne(b => b.TipoDocumento).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Despesa>().HasOne(b => b.Fornecedor).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Despesa>().HasOne(b => b.Empresa).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Despesa>().HasOne(b => b.Empreendimento).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Despesa>().HasOne(b => b.Contrato).WithMany(x => x.Despesas).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReceitaBaixa>().HasOne(x => x.FormaPagamento).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DespesaBaixa>().HasOne(x => x.FormaPagamento).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReceitaClassificacao>().HasOne(x => x.CentroCusto).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ReceitaClassificacao>().HasOne(x => x.ContaGerencial).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DespesaClassificacao>().HasOne(x => x.CentroCusto).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DespesaClassificacao>().HasOne(x => x.ContaGerencial).WithMany().OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Composicao>().HasMany(x => x.Itens).WithOne().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Composicao>().HasMany(x => x.Itens).WithOne(x => x.Composicao).HasForeignKey(x => x.ComposicaoId);
            modelBuilder.Entity<ComposicaoItem>().HasOne(x => x.Composicao).WithMany(x => x.Itens).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComposicaoItem>().HasOne(x => x.ComposicaoAuxiliar).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ComposicaoAuxiliarId);

            modelBuilder.Entity<Insumo>().OwnsOne(x => x.Estado);
            modelBuilder.Entity<Lead>().OwnsOne(x => x.Qualificacao);

            modelBuilder.Entity<Composicao>().HasMany(x => x.Itens).WithOne(x => x.Composicao).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ComposicaoItem>().HasOne(x => x.ComposicaoAuxiliar).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ComposicaoItem>().HasOne(x => x.Insumo).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pessoa>().HasOne(x => x.Usuario).WithOne().OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Pessoa>().OwnsOne(x => x.Qualificacao, y =>
            {
                y.HasOne(qualificacao => qualificacao.EstadoCivil).WithMany().OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<Pessoa>().OwnsOne(x => x.Conjuge, y =>
            {
                y.OwnsOne(conjugue => conjugue.Qualificacao, z =>
                {
                    z.HasOne(qualificacao => qualificacao.EstadoCivil).WithMany().OnDelete(DeleteBehavior.SetNull);
                });
            });

            modelBuilder.Entity<Pessoa>().OwnsOne(x => x.JuridicaResponsavel, y =>
            {
                y.OwnsOne(juridicaPessoa => juridicaPessoa.Qualificacao);
                y.OwnsOne(juridicaPessoa => juridicaPessoa.Endereco);
            });

            modelBuilder.Entity<Lote>().OwnsOne(x => x.Infraestrutura, y =>
            {
                y.OwnsOne(infraestrutura => infraestrutura.Lazer);
            });

            modelBuilder.Entity<Empreendimento>().OwnsOne(x => x.Infraestrutura, y =>
            {
                y.OwnsOne(infraestrutura => infraestrutura.Lazer);
            });


            modelBuilder.Entity<PessoaPrefeitura>().OwnsOne(x => x.Qualificacao, y =>
            {
                y.HasOne(qualificacao => qualificacao.EstadoCivil).WithMany().OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<PessoaPrefeitura>().OwnsOne(x => x.Conjuge, y =>
            {
                y.OwnsOne(conjugue => conjugue.Qualificacao, z =>
                {
                    z.HasOne(qualificacao => qualificacao.EstadoCivil).WithMany().OnDelete(DeleteBehavior.SetNull);
                });
            });

            modelBuilder.Entity<PessoaPrefeitura>()
            .OwnsOne(p => p.RegistroImportacao);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql(_stringConnection);
        }
    }
}
