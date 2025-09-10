using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Almoxarifado;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Almoxarifado
{
    public interface IAlmoxarifadoRepository : ICrudRepository<Domain.Entities.Almoxarifado.Almoxarifado>
    {
        Task<AlmoxarifadoItem> GetItem(int produtoId, int almoxarifadoId);
        Task SaveItem(AlmoxarifadoItem item);
        Task SaveItens(List<AlmoxarifadoItem> itens);
        Task InsertList(List<Domain.Entities.Almoxarifado.Almoxarifado> list);
        void RemoveList(List<Domain.Entities.Almoxarifado.Almoxarifado> list);
    }
}
