using SCAE.Data.Context;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Data.Repository.Shared;
using SCAE.Data.Interface.Almoxarifado;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Almoxarifado
{
    public class MovimentacaoRepository : CrudRepository<ScaeApiContext, Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Tipo)
            //    .Include(x => x.TipoOrigem)
            //    .Include(x => x.AlmoxarifadoItem)
            //        .ThenInclude(x => x.Produto)
            //    .Include(x => x.AlmoxarifadoItem)
            //        .ThenInclude(x => x.Almoxarifado);
        }

        public async Task InsertList(List<Movimentacao> list)
        {
            await _context.AddRangeAsync(list);
        }
    }
}
