using SCAE.Data.Context;
using SCAE.Data.Interface.Clientes;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes;

namespace SCAE.Data.Repository.Clientes
{
    public class TipoOperacaoContratoRepository : QueryRepository<ScaeApiContext, TipoOperacaoContrato>, ITipoOperacaoContratoRepository
    {
        public TipoOperacaoContratoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
