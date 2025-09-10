using SCAE.Data.Context;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.OrcamentoObras;

namespace SCAE.Data.Repository.OrcamentoObras
{
    public class OrcamentoEtapaRepository : CrudRepository<ScaeApiContext, OrcamentoEtapa>, IOrcamentoEtapaRepository
    {
        public OrcamentoEtapaRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
