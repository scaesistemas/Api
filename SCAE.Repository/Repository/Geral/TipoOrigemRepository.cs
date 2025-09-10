using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class TipoOrigemRepository : QueryRepository<ScaeApiContext, TipoOrigem>, ITipoOrigemRepository
    {
        public TipoOrigemRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
