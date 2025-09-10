using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;

namespace SCAE.Api.Controllers.Financeiro
{
    [AllowAnonymous]
    public class TipoAmortizacaoController : MasterQueryController<TipoAmortizacao>
    {
        public TipoAmortizacaoController(ILogger<TipoAmortizacaoController> logger, ITipoAmortizacaoService service) : base(logger, service)
        {
        }
    }
}
