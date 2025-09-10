using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Service.Interfaces.Financeiro.PlanoDePagamento;

namespace SCAE.Api.Controllers.Financeiro.PlanoDePagamento
{
    public class TipoAnoInicioReajusteController : MasterQueryController<TipoAnoInicioReajuste>
    {
        public TipoAnoInicioReajusteController(ILogger<TipoAnoInicioReajusteController> logger, ITipoAnoInicioReajusteService service) : base(logger, service)
        {

        }
    }
}
