using SCAE.Data.Context;
using SCAE.Data.Interface.Base;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Entities.Financeiro;
namespace SCAE.Data.Repository.Base
{
    public class TipoIndiceBaseRepository : QueryRepository<ScaeBaseContext, TipoIndiceBase>, ITipoIndiceBaseRepository
    {
        public TipoIndiceBaseRepository(ScaeBaseContext context) : base(context)
        {

        }
    }
}
