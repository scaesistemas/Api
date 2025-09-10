using SCAE.Data.Context;
using SCAE.Data.Interface.Compras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Compras;

namespace SCAE.Data.Repository.Compras
{
    public class SituacaoPedidoRepository : QueryRepository<ScaeApiContext, SituacaoPedido>, ISituacaoPedidoRepository
    {
        public SituacaoPedidoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
