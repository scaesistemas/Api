using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;

namespace SCAE.Api.Controllers.Clientes.ContratoDigitalNS
{
    public class TipoContratoDigitalController : MasterQueryController<TipoContratoDigital>
    {
        public TipoContratoDigitalController(ILogger<TipoContratoDigitalController> logger, ITipoContratoDigitalService service) : base(logger, service)
        {
        }
    }
}
