using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Financeiro.PlanoDePagamento;

namespace SCAE.Api.Controllers.Financeiro.PlanoDePagamento
{
    public class TipoPlanoPagamentoController : MasterQueryController<TipoPlanoPagamento>
    {
        public TipoPlanoPagamentoController(ILogger<TipoPlanoPagamentoController> logger, ITipoPlanoPagamentoService service) : base(logger, service)
        {

        }
    }
}
