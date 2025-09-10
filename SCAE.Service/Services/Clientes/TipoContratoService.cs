using SCAE.Data.Interface.Clientes;
using SCAE.Domain.Entities.Clientes;
using SCAE.Service.Interfaces.Clientes;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Clientes
{
    public class TipoContratoService : CrudService<TipoContrato, ITipoContratoRepository>, ITipoContratoService
    {
        public TipoContratoService(ITipoContratoRepository repository) : base(repository)
        {

        }
    }
}
