using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SCAE.Data.Context;
using SCAE.Data.Interface.Provider;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Models.Shared;

namespace SCAE.Api.Providers
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IOptions<BaseSettingModel> _baseSetting;
        private readonly IConfiguration _configuration;
        public DbContextFactory(IConfiguration configuration, IOptions<BaseSettingModel> baseSetting)
        {
            _baseSetting = baseSetting;
            _configuration = configuration;

        }

        public ScaeApiContext CreateDbContext(Assinante tenant)
        {
            var options = new DbContextOptions<ScaeApiContext>();
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ScaeApiContext>(options);
            return new ScaeApiContext(dbContextOptionsBuilder.Options, tenant, _configuration, _baseSetting);
        }
    }
}
