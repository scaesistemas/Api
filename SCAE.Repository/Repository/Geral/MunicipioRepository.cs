using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;
using System.Linq;

namespace SCAE.Data.Repository.Geral
{
    public class MunicipioRepository : QueryRepository<ScaeApiContext, Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(ScaeApiContext context) : base(context)
        {

        }

        public IQueryable<Municipio> GetByEstadoIdAsync(long estadoId)
        {
            return GetAll().Where(x => x.EstadoId == estadoId);
        }
    }
}
