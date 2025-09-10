using SCAE.Data.Context;
using SCAE.Data.Interface.Projeto;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Projeto;

namespace SCAE.Data.Repository.Projeto
{
    public class EtapaRepository : CrudRepository<ScaeApiContext, Etapa>, IEtapaRepository
    {
        public EtapaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
