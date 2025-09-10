using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.CRMVendas;

namespace SCAE.Data.Repository.Geral.CRMVendas
{
    public class OrigemLeadRepository : QueryRepository<ScaeApiContext, OrigemLead>, IOrigemLeadRepository
    {
        public OrigemLeadRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
