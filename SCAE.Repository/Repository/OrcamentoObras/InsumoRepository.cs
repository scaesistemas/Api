using SCAE.Data.Context;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.OrcamentoObras;

namespace SCAE.Data.Repository.OrcamentoObras
{
    public class InsumoRepository : CrudRepository<ScaeApiContext, Insumo>, IInsumoRepository
    {
        public InsumoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
