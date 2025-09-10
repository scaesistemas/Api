using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class TipoAmortizacaoRepository : QueryRepository<ScaeApiContext, TipoAmortizacao>, ITipoAmortizacaoRepository
    {
        public TipoAmortizacaoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
