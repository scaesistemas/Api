using SCAE.Data.Context;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.OrcamentoObras;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SCAE.Data.Repository.OrcamentoObras
{
    public class ComposicaoRepository : CrudRepository<ScaeApiContext, Composicao>, IComposicaoRepository
    {
        public ComposicaoRepository(ScaeApiContext context) : base(context)
        {
        }

        public async Task InsertList(List<Composicao> list) 
        {
            await _context.AddRangeAsync(list);
        }
    }
}
