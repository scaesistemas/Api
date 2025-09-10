using SCAE.Data.Context;
using SCAE.Data.Interface.Clientes;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes;

namespace SCAE.Data.Repository.Clientes
{
    public class TipoProdutoContratoRepository : QueryRepository<ScaeApiContext, TipoProdutoContrato>, ITipoProdutoContratoRepository
    {
        public TipoProdutoContratoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
