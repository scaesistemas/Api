using SCAE.Data.Context;
using SCAE.Data.Interface.Clientes.ContratoDigitalNS;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;

namespace SCAE.Data.Repository.Clientes.ContratoDigitalNS
{
    public class ModeloContratoDigitalRepository : CrudRepository<ScaeApiContext, ModeloContratoDigital>, IModeloContratoDigitalRepository
    {
        public ModeloContratoDigitalRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
