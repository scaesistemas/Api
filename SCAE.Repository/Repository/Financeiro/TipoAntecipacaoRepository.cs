using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;


namespace SCAE.Data.Repository.Financeiro
{
    public class TipoAntecipacaoRepository : QueryRepository<ScaeApiContext, TipoAntecipacao>, ITipoAntecipacaoRepository
    {
        public TipoAntecipacaoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
