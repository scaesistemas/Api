using SCAE.Data.Interface.Clientes.ContratoDigitalNS;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Clientes.ContratoDigitalNS
{
    public class SituacaoEmailSignatarioService : QueryService<SituacaoEmailSignatario, ISituacaoEmailSignatarioRepository>, ISituacaoEmailSignatarioService
    {
        public SituacaoEmailSignatarioService(ISituacaoEmailSignatarioRepository repository) : base(repository)
        {
        }
    }
}

