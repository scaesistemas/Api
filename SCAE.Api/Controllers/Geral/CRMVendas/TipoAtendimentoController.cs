using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral.CRMVendas;

namespace SCAE.Api.Controllers.Geral.CRMVendas
{
    [AllowAnonymous]
    public class TipoAtendimentoController : MasterQueryController<TipoAtendimento>
    {
        public TipoAtendimentoController(ILogger<TipoAtendimentoController> logger, ITipoAtendimentoService service) : base(logger, service)
        {

        }
    }
}
