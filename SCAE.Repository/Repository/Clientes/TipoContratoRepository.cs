using SCAE.Data.Context;
using SCAE.Data.Interface.Clientes;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes;

namespace SCAE.Data.Repository.Clientes
{
    public class TipoContratoRepository : CrudRepository<ScaeApiContext, TipoContrato>, ITipoContratoRepository
    {
        public TipoContratoRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.TipoOperacao);
        }
    }
}
