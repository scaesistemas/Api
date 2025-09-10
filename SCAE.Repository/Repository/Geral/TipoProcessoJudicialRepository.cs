using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class TipoProcessoJudicialRepository : CrudRepository<ScaeApiContext, TipoProcessoJudicial>, ITipoProcessoJudicialRepository
    {
        public TipoProcessoJudicialRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
