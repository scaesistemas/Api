using SCAE.Data.Context;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Data.Interface.Financeiro;

namespace SCAE.Repository.Repository.Financeiro
{
    public class TipoStatusTransacaoRepository : CrudRepository<ScaeApiContext, TipoStatusTransacao>, ITipoStatusTransacaoRepository
    {
        public TipoStatusTransacaoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}