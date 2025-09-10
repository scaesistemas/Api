using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Interfaces.Geral.CRMVendas;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral.CRMVendas
{
    public class ComoLeadContactouService : QueryService<ComoLeadContactou, IComoLeadContactouRepository>, IComoLeadContactouService
    {
        public ComoLeadContactouService(IComoLeadContactouRepository repository) : base(repository)
        {

        }
    }
}
