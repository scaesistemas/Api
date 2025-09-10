using SCAE.Data.Interface.Almoxarifado;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Service.Interfaces.Almoxarifado;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Almoxarifado
{
    public class UnidadeMedidaService : CrudService<UnidadeMedida, IUnidadeMedidaRepository>, IUnidadeMedidaService
    {
        public UnidadeMedidaService(IUnidadeMedidaRepository repository) : base(repository)
        {
        }
    }
}
