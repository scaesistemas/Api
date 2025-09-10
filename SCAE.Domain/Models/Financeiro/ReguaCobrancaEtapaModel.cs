using System.Collections.Generic;
using System.Linq;

namespace SCAE.Domain.Models.Financeiro
{
    public class ReguaCobrancaEtapaModel
    {
        public string Nome { get; set; }
        public int MinimoDiasVencido { get; set; }
        public int MaximoDiasVencido { get; set; }
        public List<ReguaCobrancaEtapaContratoModel> Contratos { get; set; }
        public int TotalParcelasEtapa => Contratos?.Sum(x => x.QuantidadeParcela) ?? 0;
        public decimal TotalValorParcelasEtapa => Contratos?.Sum(x => x.ValorTotalParcela) ?? 0;

        public ReguaCobrancaEtapaModel()
        {
            Contratos = new List<ReguaCobrancaEtapaContratoModel>();
            
        }

    }
}
