using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class TipoIndiceRepository : CrudRepository<ScaeApiContext, TipoIndice>, ITipoIndiceRepository
    {
        public TipoIndiceRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
