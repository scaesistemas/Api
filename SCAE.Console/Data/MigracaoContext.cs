using Microsoft.EntityFrameworkCore;
using SCAE.Migracao.Entities;

namespace SCAE.Migracao.Data
{
    public class MigracaoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"server=127.0.0.1;user=root;database=corporat_novarical;port=3306;password=DB@ccess;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contrato>().HasKey(x => new { x.Id, x.Sequencia });
            //modelBuilder.Entity<ContratoObservacao>().HasOne(p => p.Contrato).WithMany(x => x.Observacoes).HasForeignKey(p => new { p.ContratoId, p.Sequencia });
            //modelBuilder.Entity<Contrato>().HasMany(x => x.Observacoes).WithOne(x => x.Contrato).HasForeignKey(p => new { p.ContratoId, p.Sequencia });
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Corretor> Corretores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<ContratoImagem> Imagens { get; set; }
        public DbSet<ContratoPdf> Pdfs { get; set; }
        public DbSet<ContratoObservacao> Observacoes { get; set; }
        public DbSet<Recebivel> Recebiveis { get; set; }
        public DbSet<Loteamento> Loteamentos { get; set; }
        public DbSet<Quadra> Quadras { get; set; }
        public DbSet<ContaCorrente> ContaCorrentes { get; set; }
    }

}
