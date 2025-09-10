using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral;

namespace SCAE.Api.Controllers.Geral.CRMVendas
{
    [AllowAnonymous]
    public class MotivoCancelamentoReservaController : MasterQueryController<MotivoCancelamentoReserva>
    {
        public MotivoCancelamentoReservaController(ILogger<MotivoCancelamentoReservaController> logger, IMotivoCancelamentoReservaService service) : base(logger, service)
        {

        }
    }
}
