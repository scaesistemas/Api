using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.OrcamentoObras;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.OrcamentoObras
{
    public interface IModeloOrcamentoEtapaRepository : ICrudRepository<ModeloOrcamentoEtapa>
    {
        Task InsertList(List<ModeloOrcamentoEtapa> list);
    }
}