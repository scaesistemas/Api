using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Compras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Compras;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Compras
{
    public class ParametroRepository : CrudRepository<ScaeApiContext, Parametro>, IParametroRepository
    {
        public ParametroRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.AlmoxarifadoPadrao);
        }

        public async Task<Parametro> GetFirst()
        {
            return await GetAll().AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
