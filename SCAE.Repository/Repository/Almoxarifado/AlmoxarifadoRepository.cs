using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Almoxarifado;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Almoxarifado;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Almoxarifado
{
    public class AlmoxarifadoRepository : CrudRepository<ScaeApiContext, Domain.Entities.Almoxarifado.Almoxarifado>, IAlmoxarifadoRepository
    {
        public AlmoxarifadoRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query.Include(x => x.Itens);
        }

        public async Task<AlmoxarifadoItem> GetItem(int produtoId, int almoxarifadoId)
        {
            return await _context.AlmoxarifadoItens.AsNoTracking()
                .SingleOrDefaultAsync(x => x.ProdutoId == produtoId && x.AlmoxarifadoId == almoxarifadoId);
        }

        public async Task SaveItem(AlmoxarifadoItem item)
        {
            if (item.Id > 0)
                _context.Update(item);
            else
                _context.Add(item);

            await _context.SaveChangesAsync();
        }

        public async Task SaveItens(List<AlmoxarifadoItem> itens)
        {
            foreach (var item in itens)
            {
                if (item.Id > 0)
                    _context.Update(item);
                else
                    _context.Add(item);
            }

            await _context.SaveChangesAsync();
        }

        public async Task InsertList(List<Domain.Entities.Almoxarifado.Almoxarifado> list) 
        {
            await _context.AddRangeAsync(list);
        }

        public void RemoveList(List<Domain.Entities.Almoxarifado.Almoxarifado> list) 
        {
            _context.RemoveRange(list);
        }
    }
}
