using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Compras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Compras;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Compras
{
    public class PedidoRepository : CrudRepository<ScaeApiContext, Pedido>, IPedidoRepository
    {
        public PedidoRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Orcamento)
            //    .Include(x => x.Tipo)
            //    .Include(x => x.Fornecedor)
            //    .Include(x => x.SituacaoFrete)
            //    .Include(x => x.Itens)
            //        .ThenInclude(x => x.Produto)
            //    .Include(x => x.Itens)
            //        .ThenInclude(x => x.Situacao)
            //    .Include(x => x.Classificacoes)
            //        .ThenInclude(x => x.CentroCusto)
            //    .Include(x => x.Classificacoes)
            //        .ThenInclude(x => x.ContaGerencial);
        }

        public async Task<PedidoItem> GetItem(int id)
        {
            return await _context.Set<PedidoItem>().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<PedidoItem>> GetItens(List<int> ids)
        {
            return await _context.Set<PedidoItem>().Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task UpdateItem(PedidoItem item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateItens(List<PedidoItem> itens) 
        {
            _context.UpdateRange(itens);
            await _context.SaveChangesAsync();
        }

        private IQueryable<PedidoItem> SetInclude(IQueryable<PedidoItem> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public IQueryable<PedidoItem> ObterItens(string include = "")
        {
            var queryItens = _context.Set<PedidoItem>();

            if (string.IsNullOrEmpty(include))
                return queryItens;

            return SetInclude(queryItens, include);
        }

        public async Task RemoveXML(int arquivoId)
        {
            var arquivo = await _context.Set<PedidoXMLArquivo>().SingleOrDefaultAsync(x => x.Id == arquivoId);

            if(arquivo == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(arquivo);

        }
    }
}
