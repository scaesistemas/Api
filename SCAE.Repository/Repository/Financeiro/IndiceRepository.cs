using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class IndiceRepository : CrudRepository<ScaeApiContext, Indice>, IIndiceRepository
    {
        public IndiceRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query.Include(x => x.TipoIndice);
        }
    }
}
