using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class SeguradoraRepository : CrudRepository<ScaeApiContext, Seguradora>, ISeguradoraRepository
    {
        public SeguradoraRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
