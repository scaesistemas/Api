using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Empreendimento;

namespace SCAE.Data.Repository.Empreendimento
{
    public class SituacaoReservaRepository : QueryRepository<ScaeApiContext, SituacaoReserva>, ISituacaoReservaRepository
    {
        public SituacaoReservaRepository(ScaeApiContext context) : base(context) { }
    }
}
