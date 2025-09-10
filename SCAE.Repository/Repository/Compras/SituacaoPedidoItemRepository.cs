using SCAE.Data.Context;
using SCAE.Data.Interface.Compras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Compras;

namespace SCAE.Data.Repository.Compras
{
    public class SituacaoPedidoItemRepository : QueryRepository<ScaeApiContext, SituacaoPedidoItem>, ISituacaoPedidoItemRepository
    {
        public SituacaoPedidoItemRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
