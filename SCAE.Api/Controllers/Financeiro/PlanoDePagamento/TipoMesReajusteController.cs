using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Service.Interfaces.Financeiro.PlanoDePagamento;

namespace SCAE.Api.Controllers.Financeiro.PlanoDePagamento
{
    public class TipoMesReajusteController : MasterQueryController<TipoMesReajuste>
    {
        public TipoMesReajusteController(ILogger<TipoMesReajusteController> logger, ITipoMesReajusteService service) : base(logger, service)
        {

        }
    }
}
