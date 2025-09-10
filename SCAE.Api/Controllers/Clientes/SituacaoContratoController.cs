using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Clientes;
using SCAE.Service.Interfaces.Clientes;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Api.Controllers.Clientes
{
    public class SituacaoContratoController : MasterQueryController<SituacaoContrato>
    {
        public SituacaoContratoController(ILogger<MasterQueryController<SituacaoContrato>> logger, ISituacaoContratoService service) : base(logger, service)
        {
        }

    }
}
