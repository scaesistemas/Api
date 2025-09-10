using SCAE.Data.Interface.Clientes.ContratoDigitalNS;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;
using SCAE.Service.Services.Shared;


namespace SCAE.Service.Services.Clientes.ContratoDigitalNS
{
    public class SituacaoContratoDigitalService : QueryService<SituacaoContratoDigital, ISituacaoContratoDigitalRepository>, ISituacaoContratoDigitalService
    {
        public SituacaoContratoDigitalService(ISituacaoContratoDigitalRepository repository) : base(repository)
        {
        }
    }
}
