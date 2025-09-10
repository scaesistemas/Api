using SCAE.Data.Context;
using SCAE.Domain.Entities.Base;

namespace SCAE.Data.Interface.Provider
{
    public interface IDbContextFactory
    {
        ScaeApiContext CreateDbContext(Assinante tenant);
    }
}
