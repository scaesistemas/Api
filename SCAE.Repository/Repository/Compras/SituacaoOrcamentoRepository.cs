using SCAE.Data.Context;
using SCAE.Data.Interface.Compras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Compras;

namespace SCAE.Data.Repository.Compras
{
    public class SituacaoOrcamentoRepository : QueryRepository<ScaeApiContext, SituacaoOrcamento>, ISituacaoOrcamentoRepository
    {
        public SituacaoOrcamentoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
