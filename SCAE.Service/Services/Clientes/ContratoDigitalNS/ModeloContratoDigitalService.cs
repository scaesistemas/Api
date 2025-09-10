using SCAE.Data.Interface.Clientes.ContratoDigitalNS;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Clientes.ContratoDigitalNS
{
    public class ModeloContratoDigitalService : CrudService<ModeloContratoDigital, IModeloContratoDigitalRepository>, IModeloContratoDigitalService
    {
        public ModeloContratoDigitalService(IModeloContratoDigitalRepository repository) : base(repository)
        {
        }
    }
}
