using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class SexoRepository : QueryRepository<ScaeApiContext, Sexo>, ISexoRepository
    {
        public SexoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
