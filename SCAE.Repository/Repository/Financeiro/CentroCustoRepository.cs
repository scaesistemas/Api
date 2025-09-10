using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Financeiro
{
    public class CentroCustoRepository : CrudRepository<ScaeApiContext, CentroCusto>, ICentroCustoRepository
    {
        public CentroCustoRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query.Include(x => x.CentroCustoPai);
        }

        public async Task InsertRange(List<CentroCusto> list) 
        {
            await _context.AddRangeAsync(list);
        }
    }
}
