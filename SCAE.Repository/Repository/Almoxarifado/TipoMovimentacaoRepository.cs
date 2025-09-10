using SCAE.Data.Context;
using SCAE.Data.Interface.Almoxarifado;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Almoxarifado;

namespace SCAE.Data.Repository.Almoxarifado
{
    public class TipoMovimentacaoRepository : QueryRepository<ScaeApiContext, TipoMovimentacao>, ITipoMovimentacaoRepository
    {
        public TipoMovimentacaoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
