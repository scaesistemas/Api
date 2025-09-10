using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.CRMVendas;

namespace SCAE.Data.Repository.Geral.CRMVendas
{
    public class ComoLeadNosEncontrouRepository : QueryRepository<ScaeApiContext, ComoLeadNosEncontrou>, IComoLeadNosEncontrouRepository
    {
        public ComoLeadNosEncontrouRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
