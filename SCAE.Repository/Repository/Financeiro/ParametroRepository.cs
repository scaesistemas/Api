using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Financeiro
{
    public class ParametroRepository : CrudRepository<ScaeApiContext, Parametro>, IParametroRepository
    {
        public ParametroRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.CentroCustoReceita)
            //    .Include(x => x.ContaGerencialReceita); 
        } 

        public async Task<Parametro> GetFirst(int empresaId)
        {
            return await GetAll().AsNoTracking().Include(x => x.Gatways).ThenInclude(x => x.Tipo).FirstOrDefaultAsync(x => x.EmpresaId == empresaId);
        }

        public IQueryable<Parametro> GetAllByEmpresaId(int empresaId) 
        {
            return GetAll().AsNoTracking().Include(x => x.Gatways).ThenInclude(x => x.Tipo).Where(x=>x.EmpresaId == empresaId);
        }

        public async Task<ParametroCobranca> GetCobrancaById(int cobrancaId)
        {
            return await _context.Set<ParametroCobranca>().SingleOrDefaultAsync(x => x.Id.Equals(cobrancaId));
        }

        public async Task<ParametroGatway> GetGatewayById(int gatewayId)
        {
            return await _context.Set<ParametroGatway>().SingleOrDefaultAsync(x => x.Id.Equals(gatewayId));
        }
        public IQueryable<ParametroGatway> GetGatewayAll()
        {
            return _context.Set<ParametroGatway>();

        }
    }
}
