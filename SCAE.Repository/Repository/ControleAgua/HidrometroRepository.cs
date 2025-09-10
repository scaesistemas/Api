using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.ControleAgua;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.ControleAgua;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.ControleAgua
{
    public class HidrometroRepository : CrudRepository<ScaeApiContext, Hidrometro>, IHidrometroRepository
    {
        public HidrometroRepository(ScaeApiContext context) : base(context)
        {
        }

        private IQueryable<MarcacaoAgua> SetInclude(IQueryable<MarcacaoAgua> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public IQueryable<MarcacaoAgua> GetMarcacaoAll(string include = "")
        {
            var query = _context.Set<MarcacaoAgua>();

            if (string.IsNullOrEmpty(include))
                return query;

            return SetInclude(query, include);
        }

        public async Task<MarcacaoAgua> GetMarcacaoByIdTrackingAsync(int id, string include = "") 
        {
            var query = SetInclude(_context.Set<MarcacaoAgua>(), include);
            return await query.SingleOrDefaultAsync(x=> x.Id.Equals(id));
        }

        public void UpdateMarcacao(MarcacaoAgua marcacao)
        {
            _context.Update(marcacao);
        }
    }
}
