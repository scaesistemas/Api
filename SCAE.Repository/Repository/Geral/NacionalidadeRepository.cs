using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class NacionalidadeRepository : QueryRepository<ScaeApiContext, Nacionalidade>, INacionalidadeRepository
    {
        public NacionalidadeRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
