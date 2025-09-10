using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral
{
    public class GrauInteresseService : QueryService<GrauInteresse, IGrauInteresseRepository>, IGrauInteresseService
    {
        public GrauInteresseService(IGrauInteresseRepository repository) : base(repository) { }
    }
}
