using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class FormaPagamentoRepository : CrudRepository<ScaeApiContext, FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
