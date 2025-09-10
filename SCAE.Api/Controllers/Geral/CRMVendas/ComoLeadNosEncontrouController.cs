using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral;

namespace SCAE.Api.Controllers.Geral.CRMVendas
{
    [AllowAnonymous]
    public class ComoLeadNosEncontrouController : MasterQueryController<ComoLeadNosEncontrou>
    {
        public ComoLeadNosEncontrouController(ILogger<ComoLeadNosEncontrouController> logger, IComoLeadNosEncontrouService service) : base(logger, service)
        {

        }
    }
}
