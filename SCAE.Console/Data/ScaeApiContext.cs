using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Projeto;

namespace SCAE.Migracao.Data
{
    public class ScaeApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Pooling=true;Database=scae-novarical;User Id=postgres;Password=DB@ccess;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Seed();

            modelBuilder.Entity<Empresa>().HasIndex(x => x.CpfCnpj).IsUnique();
            modelBuilder.Entity<Pessoa>().HasIndex(x => x.CnpjCpf).IsUnique();
            modelBuilder.Entity<Usuario>().OwnsOne(x => x.Complementar);
            modelBuilder.Entity<Parametro>().HasIndex(x => x.EmpresaId).IsUnique();
            modelBuilder.Entity<CertificadoBanco>().HasOne<ContaCorrente>().WithMany(c => c.Certificados).HasForeignKey("ContaCorrenteId");

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.OwnsOne(e => e.SelfieResponsavel);
                entity.OwnsOne(e => e.FotoDocumentoResponsavel);
                entity.OwnsOne(e => e.VersoDocumentoResponsavel);
                entity.OwnsOne(e => e.ContratoSocialLtda);
            });


        }

        #region Financeiro
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<ContaCorrente> ContaCorrentes { get; set; }
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
        public DbSet<Domain.Entities.Financeiro.Parametro> FinanceiroParametros { get; set; }

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
        #endregion

        #region Clientes
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<TipoContrato> TipoContratos { get; set; }
        #endregion

        #region Compras
        public DbSet<Domain.Entities.Compras.Parametro> ComprasParametros { get; set; }
        #endregion

        #region Geral
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<TipoOrigem> TipoOrigens { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<TipoProcessoJudicial> TipoProcessoJudiciais { get; set; }
        #endregion

        #region Projeto
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<Orcado> Orcados { get; set; }
        public DbSet<ContratoFornecedor> ContratoFornecedor { get; set; }
        public DbSet<Medicao> Medicoes { get; set; }
        public DbSet<Execucao> Execucoes { get; set; }

        #endregion
    }
}
