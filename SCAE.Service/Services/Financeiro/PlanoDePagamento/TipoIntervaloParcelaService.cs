using SCAE.Data.Interface.Financeiro.PlanoDePagamento;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Service.Interfaces.Financeiro.PlanoDePagamento;
using SCAE.Service.Services.Shared;


namespace SCAE.Service.Services.Financeiro.PlanoDePagamento
{
    public class TipoIntervaloParcelaService : QueryService<TipoIntervaloParcela, ITipoIntervaloParcelaRepository>, ITipoIntervaloParcelaService
    {
        public TipoIntervaloParcelaService(ITipoIntervaloParcelaRepository repository) : base(repository)
        {
        }
    }
}
