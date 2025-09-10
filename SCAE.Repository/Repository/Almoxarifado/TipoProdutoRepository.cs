using SCAE.Data.Context;
using SCAE.Data.Interface.Almoxarifado;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Almoxarifado;

namespace SCAE.Data.Repository.Almoxarifado
{
    public class TipoProdutoRepository : QueryRepository<ScaeApiContext, TipoProduto>, ITipoProdutoRepository
    {
        public TipoProdutoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
