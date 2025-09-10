using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Service.Interfaces.Financeiro.PlanoDePagamento;

namespace SCAE.Api.Controllers.Financeiro.PlanoDePagamento
{
    public class TipoIntervaloParcelaController : MasterQueryController<TipoIntervaloParcela>
    {
        public TipoIntervaloParcelaController(ILogger<TipoIntervaloParcelaController> logger, ITipoIntervaloParcelaService service) : base(logger, service)
        {

        }
    }
}
