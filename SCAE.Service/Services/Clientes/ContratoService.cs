using SCAE.Data.Interface.Clientes;
using SCAE.Domain.Entities.Clientes;
using SCAE.Service.Interfaces.Clientes;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Clientes
{
    public class ContratoService : CrudService<Contrato, IContratoRepository>, IContratoService
    {
        public ContratoService(IContratoRepository repository) : base(repository)
        {
        }
    }
}
