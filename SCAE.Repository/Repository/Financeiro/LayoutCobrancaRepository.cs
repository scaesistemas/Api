using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class LayoutCobrancaRepository : QueryRepository<ScaeApiContext, LayoutCobranca>, ILayoutCobrancaRepository
    {
        public LayoutCobrancaRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
