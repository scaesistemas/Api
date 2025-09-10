using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class CondicaoPagamentoRepository : CrudRepository<ScaeApiContext, CondicaoPagamento>, ICondicaoPagamentoRepository
    {
        public CondicaoPagamentoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
