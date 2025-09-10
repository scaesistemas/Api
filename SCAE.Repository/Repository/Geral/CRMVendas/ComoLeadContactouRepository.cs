using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.CRMVendas;

namespace SCAE.Data.Repository.Geral.CRMVendas
{
    public class ComoLeadContactouRepository : QueryRepository<ScaeApiContext, ComoLeadContactou>, IComoLeadContactouRepository
    {
        public ComoLeadContactouRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
