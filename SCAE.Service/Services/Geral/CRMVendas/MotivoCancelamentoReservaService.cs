using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral.CRMVendas
{
    public class MotivoCancelamentoReservaService : QueryService<MotivoCancelamentoReserva, IMotivoCancelamentoReservaRepository>, IMotivoCancelamentoReservaService
    {
        public MotivoCancelamentoReservaService(IMotivoCancelamentoReservaRepository repository) : base(repository)
        {

        }
    }
}
