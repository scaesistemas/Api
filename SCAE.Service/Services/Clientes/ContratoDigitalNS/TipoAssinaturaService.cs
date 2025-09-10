using SCAE.Data.Interface.Clientes.ContratoDigitalNS;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;
using SCAE.Service.Services.Shared;


namespace SCAE.Service.Services.Clientes.ContratoDigitalNS
{
    public class TipoAssinaturaService : QueryService<TipoAssinatura, ITipoAssinaturaRepository>, ITipoAssinaturaService
    {
        public TipoAssinaturaService(ITipoAssinaturaRepository repository) : base(repository)
        {
        }
    }
}
