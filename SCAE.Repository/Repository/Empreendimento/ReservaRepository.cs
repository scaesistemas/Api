using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Empreendimento;

namespace SCAE.Data.Repository.Empreendimento
{
    public class ReservaRepository : CrudRepository<ScaeApiContext, Reserva>, IReservaRepository
    {
        public ReservaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
