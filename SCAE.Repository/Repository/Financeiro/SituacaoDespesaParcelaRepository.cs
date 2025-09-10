using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class SituacaoDespesaParcelaRepository : QueryRepository<ScaeApiContext, SituacaoDespesaParcela>, ISituacaoDespesaParcelaRepository
    {
        public SituacaoDespesaParcelaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
