using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Empreendimento;

namespace SCAE.Data.Repository.Empreendimento
{
    public class VicioRepository : CrudRepository<ScaeApiContext, Vicio>, IVicioRepository
    {
        public VicioRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
