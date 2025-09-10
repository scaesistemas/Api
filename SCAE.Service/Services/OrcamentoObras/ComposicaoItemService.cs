using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using SCAE.Service.Services.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SCAE.Service.Services.OrcamentoObras
{
    public class ComposicaoItemService : CrudService<ComposicaoItem, IComposicaoItemRepository>, IComposicaoItemService
    {
        public ComposicaoItemService(IComposicaoItemRepository repository) : base(repository)
        {
        }
        public async Task PostList(List<ComposicaoItem> list, bool saveChanges = true) 
        {
            await _repository.InsertList(list);
            if(saveChanges)
                await _repository.SaveChangesAsync();
        }
    }
}
