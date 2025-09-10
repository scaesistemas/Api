using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.CRMVendas;

namespace SCAE.Data.Repository.Geral
{
    public class GrauInteresseRepository : QueryRepository<ScaeApiContext, GrauInteresse>, IGrauInteresseRepository
    {
        public GrauInteresseRepository(ScaeApiContext context) : base(context) { }
    }
}
