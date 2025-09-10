using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.Projeto;
using SCAE.Domain.Entities.Projeto;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Projeto;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Projeto
{
    public class EtapaService : CrudService<Etapa, IEtapaRepository>, IEtapaService
    {
        private List<Etapa> _treeView;

        public EtapaService(IEtapaRepository repository) : base(repository)
        {
        }

        public override async Task Post(Etapa entity)
        {
            if (string.IsNullOrEmpty(entity.Codigo))
            {
                Etapa pai = null;

                if (entity.EtapaPaiId > 0)
                    pai = await Get(entity.EtapaPaiId.Value);

                entity.Codigo = ProximoCodigo(pai);
            }

            await base.Post(entity);
        }

        public override async Task Put(Etapa entity)
        {
            if (string.IsNullOrEmpty(entity.Codigo))
            {
                Etapa pai = null;

                if (entity.EtapaPaiId > 0)
                    pai = await Get(entity.EtapaPaiId.Value);

                entity.Codigo = ProximoCodigo(pai);
            }

            await base.Put(entity);
        }

        public async Task<List<KeyValuePair<int, string>>> ListagemSimples()
        {
            var contas = from x in
                    await GetNoInclude().ToListAsync()
                         orderby TreeViewHelper.PadNumbers(x.Codigo)
                         select new KeyValuePair<int, string>(x.Id, x.CodigoDescricao);

            return contas.ToList();
        }

        public string ProximoCodigo(Etapa pai)
        {
            var ultimoCodigo = pai == null ?
                GetNoInclude().Where(x => x.EtapaPai == null).ToList().Max(x => TreeViewHelper.PadNumbers(x.Codigo)) :
                GetNoInclude().Where(x => x.EtapaPai.Id == pai.Id).ToList().Max(x => TreeViewHelper.PadNumbers(x.Codigo));

            if (string.IsNullOrEmpty(ultimoCodigo))
            {
                return pai == null ? "1" : $"{pai.Codigo}.1";
            }

            var finalCodigo = int.Parse(ultimoCodigo.Substring(ultimoCodigo.LastIndexOf(".", StringComparison.Ordinal) + 1)) + 1;
            var novoCodigo = pai == null ? finalCodigo.ToString() : $"{pai.Codigo}.{finalCodigo}";

            return novoCodigo;
        }

        public async Task<List<Etapa>> TreeView()
        {
            _treeView = new List<Etapa>();

            var roots = from x in
                    await GetNoInclude().Where(x => x.EtapaPaiId == null).ToListAsync()
                        orderby TreeViewHelper.PadNumbers(x.Codigo)
                        select x;

            foreach (var root in roots)
            {
                _treeView.Add(root);

                AddChildren(root);
            }

            return _treeView;
        }

        private void AddChildren(Etapa root)
        {
            var children = GetNoInclude().Where(x => x.EtapaPaiId == root.Id).ToList();

            if (!children.Any())
                return;

            root.Children = new List<Etapa>();

            foreach (var child in children)
            {
                root.Children.Add(child);

                AddChildren(child);
            }
        }
    }
}
