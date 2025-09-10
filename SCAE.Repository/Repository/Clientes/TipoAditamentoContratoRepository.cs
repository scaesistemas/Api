using SCAE.Data.Context;
using SCAE.Data.Interface.Clientes;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes;

namespace SCAE.Data.Repository.Clientes
{
    public class TipoAditamentoContratoRepository : QueryRepository<ScaeApiContext, TipoAditamentoContrato>, ITipoAditamentoContratoRepository
    {
        public TipoAditamentoContratoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
