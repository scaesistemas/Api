using SCAE.Data.Context;
using SCAE.Data.Interface.Base;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Base;


namespace SCAE.Data.Repository.Base
{
    public class IndiceBaseRepository : CrudRepository<ScaeBaseContext, IndiceBase>, IIndiceBaseRepository
    {
        public IndiceBaseRepository(ScaeBaseContext context) : base(context)
        {
        }

    }
}
