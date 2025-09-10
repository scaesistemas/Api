using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class EstadoRepository : QueryRepository<ScaeApiContext, Estado>, IEstadoRepository
    {
        public EstadoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
