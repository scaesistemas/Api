using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.CRMVendas;

namespace SCAE.Data.Repository.Geral.CRMVendas
{
    public class MotivoCancelamentoReservaRepository : QueryRepository<ScaeApiContext, MotivoCancelamentoReserva>, IMotivoCancelamentoReservaRepository
    {
        public MotivoCancelamentoReservaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
