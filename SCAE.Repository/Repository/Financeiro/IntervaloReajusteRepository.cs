using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class IntervaloReajusteRepository : QueryRepository<ScaeApiContext, IntervaloReajuste>, IIntervaloReajusteRepository
    {
        public IntervaloReajusteRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
