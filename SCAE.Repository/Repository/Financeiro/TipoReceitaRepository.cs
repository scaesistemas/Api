using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class TipoReceitaRepository : QueryRepository<ScaeApiContext, TipoReceita>, ITipoReceitaRepository
    {
        public TipoReceitaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
