using SCAE.Data.Context;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.OrcamentoObras;

namespace SCAE.Data.Repository.OrcamentoObras
{
    public class OrcamentoEtapaItemRepository : CrudRepository<ScaeApiContext, OrcamentoEtapaItem>, IOrcamentoEtapaItemRepository
    {
        public OrcamentoEtapaItemRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
