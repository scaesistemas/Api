using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Geral;
using System.Linq;

namespace SCAE.Data.Interface.Geral
{
    public interface IMunicipioRepository : IQueryRepository<Municipio>
    {
        IQueryable<Municipio> GetByEstadoIdAsync(long estadoId);
    }
}
