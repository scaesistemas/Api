using System;
using System.Text.RegularExpressions;
using System.Linq;
using SCAE.Domain.Entities.Financeiro;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SCAE.Data.Repository.Shared;
using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class ContaGerencialRepository : CrudRepository<ScaeApiContext, ContaGerencial>, IContaGerencialRepository
    {
        private List<ContaGerencial> _treeView;

        public ContaGerencialRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query.Include(x => x.ContaGerencialPai);
        }

        public async Task<List<KeyValuePair<int, string>>> ListagemSimples()
        {
            return await ListagemSimples(null);
        }

        public async Task<List<KeyValuePair<int, string>>> ListagemSimples(string tipo)
        {
            var contas = from x in
                    !string.IsNullOrEmpty(tipo) ? await _context.ContaGerenciais.Where(x => x.Tipo == tipo).ToListAsync() : await _context.ContaGerenciais.ToListAsync()
                         orderby PadNumbers(x.Codigo)
                         select new KeyValuePair<int, string>(x.Id, x.CodigoDescricao);

            return contas.ToList();
        }

        public string ProximoCodigo(ContaGerencial pai)
        {
            var ultimoCodigo = pai == null ?
                _context.ContaGerenciais.AsNoTracking().Where(x => x.ContaGerencialPai == null).ToList().Max(x => PadNumbers(x.Codigo)) :
                _context.ContaGerenciais.AsNoTracking().Where(x => x.ContaGerencialPai.Id == pai.Id).ToList().Max(x => PadNumbers(x.Codigo));

            if (string.IsNullOrEmpty(ultimoCodigo))
            {
                return pai == null ? "1" : $"{pai.Codigo}.1";
            }

            var finalCodigo = int.Parse(ultimoCodigo.Substring(ultimoCodigo.LastIndexOf(".", StringComparison.Ordinal) + 1)) + 1;
            var novoCodigo = pai == null ? finalCodigo.ToString() : $"{pai.Codigo}.{finalCodigo}";

            return novoCodigo;
        }

        public async Task<List<ContaGerencial>> TreeView(string tipo)
        {
            _treeView = new List<ContaGerencial>();

            var roots = from x in
                    !string.IsNullOrEmpty(tipo) ? 
                        await _context.ContaGerenciais.Where(x => x.ContaGerencialPaiId == null && x.Tipo == tipo).ToListAsync() : 
                        await _context.ContaGerenciais.Where(x => x.ContaGerencialPaiId == null).ToListAsync()
                            orderby PadNumbers(x.Codigo)
                            select x;

            foreach (var root in roots)
            {
                //var item = new TreeViewResult(root.Id, root.Descricao);
                _treeView.Add(root);

                AddChildren(root);
            }

            return _treeView;
        }

        private void AddChildren(ContaGerencial root)
        {
            var children = _context.ContaGerenciais.Where(x => x.ContaGerencialPaiId == root.Id).ToList();

            if (!children.Any())
                return;

            root.Children = new List<ContaGerencial>();

            foreach (var child in children)
            {
                //var item = new TreeViewResult(child.Id, $"{child.Codigo} - {child.Nome}");
                root.Children.Add(child);

                AddChildren(child);
            }
        }

        public string PadNumbers(string input)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }

        public async Task InsertList(List<ContaGerencial> list) 
        {
            await _context.AddRangeAsync(list);
        }
    }
}
