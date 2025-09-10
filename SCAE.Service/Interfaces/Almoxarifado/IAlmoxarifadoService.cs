using DocumentFormat.OpenXml.Office2010.ExcelAc;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Service.Interfaces.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Almoxarifado
{
    public interface IAlmoxarifadoService : ICrudService<Domain.Entities.Almoxarifado.Almoxarifado>
    {
        Task<AlmoxarifadoItem> GetItem(int produtoId, int almoxarifadoId);
        Task SaveItem(AlmoxarifadoItem item);
        Task SaveItens(List<AlmoxarifadoItem> itens);
        Task PostList(List<Domain.Entities.Almoxarifado.Almoxarifado> list, bool saveChanges = true);
        Task DeleteList(List<Domain.Entities.Almoxarifado.Almoxarifado> list, bool saveChanges = true);
    }
}
