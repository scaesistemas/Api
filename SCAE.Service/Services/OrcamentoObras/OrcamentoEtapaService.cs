using DocumentFormat.OpenXml.Office2010.ExcelAc;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using SCAE.Service.Services.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SCAE.Framework.Helper;

namespace SCAE.Service.Services.OrcamentoObras
{
    public class OrcamentoEtapaService : CrudService<OrcamentoEtapa, IOrcamentoEtapaRepository>, IOrcamentoEtapaService
    {
        private List<OrcamentoEtapa> _treeView;
        public OrcamentoEtapaService(IOrcamentoEtapaRepository repository) : base(repository)
        {
        }

        public async Task<List<OrcamentoEtapa>> TreeView(int orcamentoId) 
        {
            _treeView = new List<OrcamentoEtapa>();

            var roots = from x in
                    await GetNoInclude().Where(x => x.EtapaPaiId == null && x.OrcamentoId == orcamentoId).ToListAsync()
                        orderby TreeViewHelper.PadNumbers(x.Titulo)
                        select x;

            foreach (var root in roots)
            {
                _treeView.Add(root);

                AddChildren(root);
            }

            return _treeView;
        }

        private void AddChildren(OrcamentoEtapa root)
        {
            var children = GetNoInclude().Where(x => x.EtapaPaiId == root.Id).ToList();

            if (!children.Any())
                return;

            root.Children = new List<OrcamentoEtapa>();

            foreach (var child in children)
            {
                root.Children.Add(child);

                AddChildren(child);
            }
        }
    }
}
