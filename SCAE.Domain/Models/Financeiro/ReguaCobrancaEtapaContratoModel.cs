using System;

namespace SCAE.Domain.Models.Financeiro
{
    public class ReguaCobrancaEtapaContratoModel
    {
        public int Id { get; set; }
        public String Numero { get; set; }
        public int QuantidadeParcela{ get; set; }
        public decimal ValorTotalParcela{ get; set; }
        public DateTime ParcelaMaisAntiga { get; set; }

        public string EmpreendimentoNome { get; set; }
        public string QuadraNome { get; set; }
        public string UnidadeNome { get; set; }

        public string SituacaoContrato { get; set; }

        public string ClienteNome { get; set; } 

    }
}
