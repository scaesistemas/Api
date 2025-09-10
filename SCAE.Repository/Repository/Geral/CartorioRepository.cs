using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Geral
{
    public class CartorioRepository : CrudRepository<ScaeApiContext, Cartorio>, ICartorioRepository
    {
        public CartorioRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Estado)
            //    .Include(x => x.Municipio);
        }

        public async Task<Cartorio> GetByNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return await GetAll().FirstOrDefaultAsync(x => x.Nome == nome);
        }
    }
}
