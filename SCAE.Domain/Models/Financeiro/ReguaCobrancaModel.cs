using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro
{
    public class ReguaCobrancaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ReguaCobrancaEtapaModel> Etapas { get; set; }
        public int TotalParcelas => Etapas?.Sum(x => x.TotalParcelasEtapa) ?? 0;
        public decimal ValorTotal => Etapas?.Sum(x => x.TotalValorParcelasEtapa) ?? 0;
        public ReguaCobrancaModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Etapas = new List<ReguaCobrancaEtapaModel>();
        }

    }
}
