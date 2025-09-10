using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class EstadoCivilRepository : QueryRepository<ScaeApiContext, EstadoCivil>, IEstadoCivilRepository
    {
        public EstadoCivilRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
