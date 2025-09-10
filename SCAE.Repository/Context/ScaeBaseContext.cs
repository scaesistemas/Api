using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SCAE.Data.Extension;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Shared;
using System.Collections.Generic;

namespace SCAE.Data.Context
{
    public class ScaeBaseContext : DbContext
    {
        private readonly BaseSettingModel _baseSetting;
        private readonly string _stringConnection;

        public ScaeBaseContext(DbContextOptions<ScaeBaseContext> options, IConfiguration configuration, IOptions<BaseSettingModel> baseSetting) 
            : base(options)
        {
            _baseSetting = baseSetting.Value;
            _stringConnection = string.Format(configuration.GetConnectionString("BasePrincipal"), 
                _baseSetting.Host, _baseSetting.Port, _baseSetting.Pooling, _baseSetting.PrefixDatabase, _baseSetting.Database,
                _baseSetting.User, _baseSetting.Password);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedBase();

            modelBuilder.Entity<Assinante>().HasIndex(x => x.CpfCnpj).IsUnique();
            modelBuilder.Entity<Assinante>().HasIndex(x => x.SubDominio).IsUnique();
            modelBuilder.Entity<AdiantamentoCarteira>()
                        .HasMany(a => a.AdiantamentoContratos)
                        .WithOne(c => c.AdiantamentoCarteira)
                        .HasForeignKey(c => c.AdiantamentoCarteiraId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AdiantamentoCarteira>()
             .HasMany(a => a.SplitPagamentos)
             .WithOne(c => c.AdiantamentoCarteira)
             .HasForeignKey(c => c.AdiantamentoCarteiraId)
             .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_stringConnection);
        }

        public DbSet<Assinante> Assinantes { get; set; }
        public DbSet<TermosDeUso> TermosDeUsos { get; set; }
        public DbSet<TipoTermoEmpresa> TipoTermoEmpresas { get; set; }
        public DbSet<AdiantamentoCarteira> AdiantamentoCarteiras { get; set; }
        public DbSet<ContratoAdiantamento> ContratosAdiantamentos { get; set; }
        public DbSet<SplitPagamentoBase> SplitPagamentoBases { get; set; }
        public DbSet<IndiceBase> BaseIndices { get; set; }
        public DbSet<TipoIndiceBase> TipoBaseIndices { get; set; }

        #region Geral
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Estado> Estados { get; set; }
        #endregion
    }
}
