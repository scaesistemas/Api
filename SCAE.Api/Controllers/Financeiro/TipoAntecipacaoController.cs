using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Api.Controllers.Financeiro
{
    public class TipoAntecipacaoController : MasterQueryController<TipoAntecipacao>
    {
        public TipoAntecipacaoController(ILogger<TipoAntecipacaoController> logger, ITipoAntecipacaoService service) : base(logger, service)
        {

        }
    }
}
