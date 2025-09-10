using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral;

namespace SCAE.Api.Controllers.Geral.CRMVendas
{
    [AllowAnonymous]
    public class ComoLeadContactouController : MasterQueryController<ComoLeadContactou>
    {
        public ComoLeadContactouController(ILogger<ComoLeadContactouController> logger, IComoLeadContactouService service) : base(logger, service)
        {

        }
    }
}
