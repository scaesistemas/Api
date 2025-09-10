using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Almoxarifado;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Almoxarifado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Almoxarifado
{
    public class ProdutoRepository : CrudRepository<ScaeApiContext, Produto>, IProdutoRepository
    {
        public ProdutoRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Grupo)
            //    .Include(x => x.Tipo)
            //    .Include(x => x.AlmoxarifadoItens)
            //        .ThenInclude(y => y.Almoxarifado);
        }

        public async Task<List<Produto>> AutoComplete(string q)
        {
            var query = _context.Produtos
                                .Include(x => x.AlmoxarifadoItens)
                                    .ThenInclude(y => y.Almoxarifado)
                                .AsNoTracking();

            query = EncontrarPorNomeCodigo(query, q);

            return await query.ToListAsync();
        }

        public async Task<Produto> GetByCodigoFornecedor(int fornecedorId,string codigo)
        {
            return await _context.Produtos.AsNoTracking().SingleOrDefaultAsync(x => x.Fornecedores.Any(x => x.FornecedorId == fornecedorId && x.Codigo == codigo));
        }

        public async Task<Produto> GetPrimeiraSugestao(string nomeCodigo)
        {
            var query = _context.Produtos.AsNoTracking();

            query = EncontrarPorNomeCodigoSeparandoEspacos(query, nomeCodigo); 

            return await query.FirstOrDefaultAsync();

        }

        private IQueryable<Produto> EncontrarPorNomeCodigoSeparandoEspacos(IQueryable<Produto> query, string nomeCodigo)
        {
            var tempQuery = query.Where(x => (x.Nome.ToUpper().Contains(nomeCodigo.ToUpper()) || x.Codigo.ToUpper().Contains(nomeCodigo.ToUpper())) && x.Ativo);

            if (tempQuery.Count() <= 0)
            {
                string[] palavras = nomeCodigo.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var palavra in palavras)
                {
                   var retornoQuery = EncontrarPorNomeCodigo(query, palavra);
                    if(retornoQuery.Count() >= 0)
                    {
                        query = retornoQuery;
                        break;
                    }
                }
            }
            else
                query = tempQuery;
            return query;
        }

        private IQueryable<Produto> EncontrarPorNomeCodigo(IQueryable<Produto> query, string nomeCodigo)
        {
             query = query.Where(x => (x.Nome.ToUpper().Contains(nomeCodigo.ToUpper()) || x.Codigo.ToUpper().Contains(nomeCodigo.ToUpper())) && x.Ativo);
            return query;
        }

        public void UpdateList(List<Produto> list) 
        {
            _context.UpdateRange(list);
        }
    }
}
