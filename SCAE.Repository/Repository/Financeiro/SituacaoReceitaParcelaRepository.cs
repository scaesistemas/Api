using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class SituacaoReceitaParcelaRepository : QueryRepository<ScaeApiContext, SituacaoReceitaParcela>, ISituacaoReceitaParcelaRepository
    {
        public SituacaoReceitaParcelaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
