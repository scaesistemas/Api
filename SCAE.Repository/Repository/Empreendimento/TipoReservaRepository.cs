using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Empreendimento;

namespace SCAE.Data.Repository.Empreendimento
{
    public class TipoReservaRepository : QueryRepository<ScaeApiContext, TipoReserva>, ITipoReservaRepository
    {
        public TipoReservaRepository(ScaeApiContext context) : base(context) { }
    }
}
