using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro.PlanoDePagamento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;

namespace SCAE.Data.Repository.Financeiro.PlanoDePagamento
{
    public class TipoMesReajusteRepository : QueryRepository<ScaeApiContext, TipoMesReajuste>, ITipoMesReajusteRepository
    {
        public TipoMesReajusteRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
