using SCAE.Data.Interface.Base;
using SCAE.Domain.Entities.Base;
using SCAE.Service.Interfaces.Base;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Base
{
    public class TipoIndiceBaseService : QueryService<TipoIndiceBase, ITipoIndiceBaseRepository>, ITipoIndiceBaseService
    {
        public TipoIndiceBaseService(ITipoIndiceBaseRepository repository) : base(repository)
        {

        }
    }
}
