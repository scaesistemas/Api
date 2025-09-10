using SCAE.Data.Interface.Base;
using SCAE.Domain.Entities.Base;
using SCAE.Service.Interfaces.Base;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Base
{
    public class IndiceBaseService : CrudService<IndiceBase, IIndiceBaseRepository>, IIndiceBaseService
    {
        public IndiceBaseService(IIndiceBaseRepository repository) : base(repository)
        {
        }
    }
}
