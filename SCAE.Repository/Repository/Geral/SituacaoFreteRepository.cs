using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class SituacaoFreteRepository : QueryRepository<ScaeApiContext, SituacaoFrete>, ISituacaoFreteRepository
    {
        public SituacaoFreteRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
