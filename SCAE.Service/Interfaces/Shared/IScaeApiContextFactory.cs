using SCAE.Data.Context;
using SCAE.Domain.Entities.Base;

namespace SCAE.Service.Interfaces.Shared
{
    public interface IScaeApiContextFactory
    {
        ScaeApiContext Create(Assinante assinante);
    }
}