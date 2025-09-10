using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Almoxarifado;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Almoxarifado;

namespace SCAE.Data.Repository.Almoxarifado
{
    public class InventarioRepository : CrudRepository<ScaeApiContext, Inventario>, IInventarioRepository
    {
        public InventarioRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Almoxarifado)
            //    .Include(x => x.Itens)
            //    .ThenInclude(x => x.Produto);
        }
    }
}
