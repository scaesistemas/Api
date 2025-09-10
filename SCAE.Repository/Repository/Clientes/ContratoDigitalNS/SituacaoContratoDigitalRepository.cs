using SCAE.Data.Context;
using SCAE.Data.Interface.Clientes.ContratoDigitalNS;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;


namespace SCAE.Data.Repository.Clientes.ContratoDigitalNS
{
    public class SituacaoContratoDigitalRepository : QueryRepository<ScaeApiContext, SituacaoContratoDigital>, ISituacaoContratoDigitalRepository
    {
        public SituacaoContratoDigitalRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
