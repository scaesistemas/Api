using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class GrauParentescoRepository : QueryRepository<ScaeApiContext, GrauParentesco>, IGrauParentescoRepository
    {
        public GrauParentescoRepository(ScaeApiContext context) : base(context) 
        {
        
        }
    }
}
