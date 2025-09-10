using SCAE.Data.Context;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.OrcamentoObras;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.OrcamentoObras
{
    public class ModeloOrcamentoEtapaRepository : CrudRepository<ScaeApiContext, ModeloOrcamentoEtapa>, IModeloOrcamentoEtapaRepository
    {
        public ModeloOrcamentoEtapaRepository(ScaeApiContext context) : base(context)
        {
        }

        public async Task InsertList(List<ModeloOrcamentoEtapa> list)
        {
            await _context.AddRangeAsync(list);
        }
    }
}
