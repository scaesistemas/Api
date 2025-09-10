using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class TipoDocumentoRepository : CrudRepository<ScaeApiContext, TipoDocumento>, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
