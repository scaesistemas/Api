using SCAE.Data.Context;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.OrcamentoObras;

namespace SCAE.Data.Repository.OrcamentoObras
{
    public class TipoComposicaoRepository : CrudRepository<ScaeApiContext, TipoComposicao>, ITipoComposicaoRepository
    {
        public TipoComposicaoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
