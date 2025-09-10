using SCAE.Data.Context;
using SCAE.Data.Interface.Clientes.ContratoDigitalNS;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;

namespace SCAE.Data.Repository.Clientes.ContratoDigitalNS
{
    public class TipoContratoDigitalRepository : QueryRepository<ScaeApiContext, TipoContratoDigital>, ITipoContratoDigitalRepository
    {
        public TipoContratoDigitalRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
