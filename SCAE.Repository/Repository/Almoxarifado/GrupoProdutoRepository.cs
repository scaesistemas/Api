using SCAE.Data.Context;
using SCAE.Data.Interface.Almoxarifado;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Almoxarifado;

namespace SCAE.Data.Repository.Almoxarifado
{
    public class GrupoProdutoRepository : CrudRepository<ScaeApiContext, GrupoProduto>, IGrupoProdutoRepository
    {
        public GrupoProdutoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
