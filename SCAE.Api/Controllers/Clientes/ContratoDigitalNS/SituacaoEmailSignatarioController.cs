using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;

namespace SCAE.Api.Controllers.Clientes.ContratoDigitalNS
{
    public class SituacaoEmailSignatarioController : MasterQueryController<SituacaoEmailSignatario>
    {
        public SituacaoEmailSignatarioController(ILogger<SituacaoEmailSignatarioController> logger, ISituacaoEmailSignatarioService service) : base(logger, service)
        {
        }
    }
}
