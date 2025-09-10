using SCAE.Data.Context;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Repository.Shared;

namespace SCAE.Data.Repository.OrcamentoObras
{
    public class OrcamentoObrasRepository : CrudRepository<ScaeApiContext, Domain.Entities.OrcamentoObras.OrcamentoObras>, IOrcamentoObrasRepository
    {
        public OrcamentoObrasRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
