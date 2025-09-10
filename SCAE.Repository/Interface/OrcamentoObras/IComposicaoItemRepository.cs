using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.OrcamentoObras;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.OrcamentoObras
{
    public interface IComposicaoItemRepository : ICrudRepository<ComposicaoItem>
    {
        Task InsertList(List<ComposicaoItem> list);
    }
}
