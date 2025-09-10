using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class TipoDespesaRepository : QueryRepository<ScaeApiContext, TipoDespesa>, ITipoDespesaRepository
    {
        public TipoDespesaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
