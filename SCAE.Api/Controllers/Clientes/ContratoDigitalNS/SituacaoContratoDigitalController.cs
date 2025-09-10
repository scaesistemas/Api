using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Api.Controllers.Clientes.ContratoDigitalNS
{
    public class SituacaoContratoDigitalController : MasterQueryController<SituacaoContratoDigital>
    {
        public SituacaoContratoDigitalController(ILogger<SituacaoContratoDigitalController> logger, ISituacaoContratoDigitalService service) : base(logger, service)
        {
        }
    }
}
