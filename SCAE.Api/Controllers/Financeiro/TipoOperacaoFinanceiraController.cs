using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;

namespace SCAE.Api.Controllers.Financeiro
{
    [AllowAnonymous]
    public class TipoOperacaoFinanceiraController : MasterQueryController<TipoOperacaoFinanceira>
    {
        public TipoOperacaoFinanceiraController(ILogger<TipoOperacaoFinanceiraController> logger, ITipoOperacaoFinanceiraService service) : base(logger, service)
        {

        }
    }
}
