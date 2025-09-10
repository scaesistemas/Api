using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class TipoOperacaoFinanceiraRepository : QueryRepository<ScaeApiContext, TipoOperacaoFinanceira>, ITipoOperacaoFinanceiraRepository
    {
        public TipoOperacaoFinanceiraRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
