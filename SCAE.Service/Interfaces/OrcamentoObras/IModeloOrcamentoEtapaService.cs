using SCAE.Domain.Entities.OrcamentoObras;
using ObrasDomain = SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.OrcamentoObras
{
    public interface IModeloOrcamentoEtapaService : ICrudService<ModeloOrcamentoEtapa>
    {
        Task SalvarComoModelo(int id, int estadoId);
        Task<ModeloOrcamentoEtapa> GetMenorIdNoTracking(string include);
        Task<ModeloOrcamentoEtapa> GetTreeViewNoTracking(int id);
        Task<List<ModeloOrcamentoEtapa>> GetTreeViewNoTracking();
        Task<int> AplicarModelo(int id, ObrasDomain.OrcamentoObras orcamentoModelo, int? etapaPaiId);
    }
}