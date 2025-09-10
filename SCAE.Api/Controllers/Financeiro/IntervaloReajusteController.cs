using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Api.Controllers.Financeiro
{
    [AllowAnonymous]
    public class IntervaloReajusteController : MasterQueryController<IntervaloReajuste>
    {
        public IntervaloReajusteController(ILogger<IntervaloReajusteController> logger, IIntervaloReajusteService service) : base(logger, service)
        {
        }
    }
}
