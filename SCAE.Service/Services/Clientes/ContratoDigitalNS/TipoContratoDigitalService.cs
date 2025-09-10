using SCAE.Data.Interface.Clientes.ContratoDigitalNS;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Clientes.ContratoDigitalNS
{
    public class TipoContratoDigitalService : QueryService<TipoContratoDigital, ITipoContratoDigitalRepository>, ITipoContratoDigitalService
    {
        public TipoContratoDigitalService(ITipoContratoDigitalRepository repository) : base(repository)
        {
        }
    }
}
