using SCAE.Data.Interface.Financeiro.PlanoDePagamento;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Service.Interfaces.Financeiro.PlanoDePagamento;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Financeiro.PlanoDePagamento
{
    public class TipoAnoInicioReajusteService : QueryService<TipoAnoInicioReajuste, ITipoAnoInicioReajusteRepository>, ITipoAnoInicioReajusteService
    {
        public TipoAnoInicioReajusteService(ITipoAnoInicioReajusteRepository repository) : base(repository)
        {
        }
    }
}
