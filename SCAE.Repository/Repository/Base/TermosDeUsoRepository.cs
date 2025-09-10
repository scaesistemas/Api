using SCAE.Data.Context;
using SCAE.Data.Interface.Base;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Base;

namespace SCAE.Data.Repository.Base
{
    public class TermosDeUsoRepository : CrudRepository<ScaeBaseContext, TermosDeUso>, ITermosDeUsoRepository
    {
        public TermosDeUsoRepository(ScaeBaseContext context) : base(context)
        {
        }
    }
}
