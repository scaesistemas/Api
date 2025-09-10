using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioInadimplenciaModel
    {        
        public List<RelatorioInadimplenciaItemModel> Etapas { get; set; }
        public int TotalParcelas { get; set; }
        public Decimal ValorTotal { get; set; }
        public RelatorioInadimplenciaModel()
        {
            Etapas = new List<RelatorioInadimplenciaItemModel>();
        }
    }
    public class RelatorioInadimplenciaItemModel
    {
        public string TempoMinMax { get; set; }
        public int TotalParcelaEtapa { get; set; }
        public Decimal TotalValorEtapa { get; set; }
        
    }
}
