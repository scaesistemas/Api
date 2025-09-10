using SCAE.Data.Interface.Compras;
using SCAE.Domain.Entities.Compras;
using SCAE.Service.Interfaces.Compras;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Compras
{
    public class SituacaoPedidoService : QueryService<SituacaoPedido, ISituacaoPedidoRepository>, ISituacaoPedidoService
    {
        public SituacaoPedidoService(ISituacaoPedidoRepository repository) : base(repository)
        {

        }
    }
}
