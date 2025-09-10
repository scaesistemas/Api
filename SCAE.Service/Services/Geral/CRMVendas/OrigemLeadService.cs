using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral.CRMVendas;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral.CRMVendas
{
    public class OrigemLeadService : QueryService<OrigemLead, IOrigemLeadRepository>, IOrigemLeadService
    {
        public OrigemLeadService(IOrigemLeadRepository repository) : base(repository)
        {

        }
    }
}
