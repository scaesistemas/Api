using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class TipoRemessaRepository : QueryRepository<ScaeApiContext, TipoRemessa>, ITipoRemessaRepository
    {
        public TipoRemessaRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
