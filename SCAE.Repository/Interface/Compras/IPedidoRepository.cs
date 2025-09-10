using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Compras;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Compras
{
    public interface IPedidoRepository : ICrudRepository<Pedido>
    {
        Task<PedidoItem> GetItem(int id);
        Task<List<PedidoItem>> GetItens(List<int> ids);
        Task UpdateItem(PedidoItem item);
        Task UpdateItens(List<PedidoItem> itens);
        IQueryable<PedidoItem> ObterItens(string include = "");
        Task RemoveXML(int arquivoId);
    }
}
