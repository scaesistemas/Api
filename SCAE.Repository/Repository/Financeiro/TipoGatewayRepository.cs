using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class TipoGatewayRepository : QueryRepository<ScaeApiContext, TipoGateway>, ITipoGatewayRepository
    {
        public TipoGatewayRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
