using SCAE.Data.Context;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.OrcamentoObras;

namespace SCAE.Data.Repository.OrcamentoObras
{
    public class TipoInsumoRepository : QueryRepository<ScaeApiContext, TipoInsumo>, ITipoInsumoRepository
    {
        public TipoInsumoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
