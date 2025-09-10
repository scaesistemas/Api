using System.Collections.Generic;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.OrcamentoObras
{
    public interface IComposicaoItemService : ICrudService<ComposicaoItem>
    {
        Task PostList(List<ComposicaoItem> list, bool saveChanges = true);
    }
}
