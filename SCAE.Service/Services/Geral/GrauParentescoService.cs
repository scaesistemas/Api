using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral
{
    public class GrauParentescoService : QueryService<GrauParentesco, IGrauParentescoRepository>, IGrauParentescoService
    {
        public GrauParentescoService(IGrauParentescoRepository repository) : base(repository) { }
    }
}
