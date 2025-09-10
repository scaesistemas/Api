using DocumentFormat.OpenXml.Office2010.ExcelAc;
using SCAE.Data.Interface.Almoxarifado;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Service.Interfaces.Almoxarifado;
using SCAE.Service.Services.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Almoxarifado
{
    public class AlmoxarifadoService : CrudService<Domain.Entities.Almoxarifado.Almoxarifado, IAlmoxarifadoRepository>, IAlmoxarifadoService
    {
        public AlmoxarifadoService(IAlmoxarifadoRepository repository) : base(repository)
        {
        }

        public async Task<AlmoxarifadoItem> GetItem(int produtoId, int almoxarifadoId)
        {
            return await _repository.GetItem(produtoId, almoxarifadoId);
        }

        public async Task SaveItem(AlmoxarifadoItem item)
        {
            await _repository.SaveItem(item);
        }
        public async Task SaveItens(List<AlmoxarifadoItem> itens) 
        {
            await _repository.SaveItens(itens);
        }

        public async Task PostList(List<Domain.Entities.Almoxarifado.Almoxarifado> list, bool saveChanges = true) 
        {
            await _repository.InsertList(list);
            if(saveChanges)
                await _repository.SaveChangesAsync();
        }

        public async Task DeleteList(List<Domain.Entities.Almoxarifado.Almoxarifado> list, bool saveChanges = true) 
        {
            _repository.RemoveList(list);

            if(saveChanges)
                await _repository.SaveChangesAsync();
        }
    }
}
