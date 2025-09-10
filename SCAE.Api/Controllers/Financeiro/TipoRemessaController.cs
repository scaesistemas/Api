using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;

namespace SCAE.Api.Controllers.Financeiro
{
    public class TipoRemessaController : MasterQueryController<TipoRemessa>
    {
        public TipoRemessaController(ILogger<TipoRemessaController> logger, ITipoRemessaService service) : base(logger, service)
        {
        }
    }
}
