using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class TipoServicoParcelaRepository : CrudRepository<ScaeApiContext, TipoServicoParcela>, ITipoServicoParcelaRepository
    {
        public TipoServicoParcelaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
