using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class LogRepository : CrudRepository<ScaeApiContext, Log>, ILogRepository
    {
        public LogRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
