using SCAE.Data.Context;
using SCAE.Data.Interface.Almoxarifado;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Almoxarifado;

namespace SCAE.Data.Repository.Almoxarifado
{
    public class UnidadeMedidaRepository : CrudRepository<ScaeApiContext, UnidadeMedida>, IUnidadeMedidaRepository
    {
        public UnidadeMedidaRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
