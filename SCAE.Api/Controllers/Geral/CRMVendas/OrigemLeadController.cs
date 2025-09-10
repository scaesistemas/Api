using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral.CRMVendas;

namespace SCAE.Api.Controllers.Geral.CRMVendas
{
    [AllowAnonymous]
    public class OrigemLeadController : MasterQueryController<OrigemLead>
    {
        public OrigemLeadController(ILogger<OrigemLeadController> logger, IOrigemLeadService service) : base(logger, service)
        {

        }
    }
}
