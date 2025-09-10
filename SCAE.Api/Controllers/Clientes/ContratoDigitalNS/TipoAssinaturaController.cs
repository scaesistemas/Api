using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;

namespace SCAE.Api.Controllers.Clientes.ContratoDigitalNS
{
    public class TipoAssinaturaController : MasterQueryController<TipoAssinatura>
    {
        public TipoAssinaturaController(ILogger<TipoAssinaturaController> logger, ITipoAssinaturaService service) : base(logger, service)
        {
        }
    }
}
