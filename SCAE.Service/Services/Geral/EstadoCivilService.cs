using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral
{
    public class EstadoCivilService : QueryService<EstadoCivil, IEstadoCivilRepository>, IEstadoCivilService
    {
        public EstadoCivilService(IEstadoCivilRepository repository) : base(repository)
        {

        }
    }
}
