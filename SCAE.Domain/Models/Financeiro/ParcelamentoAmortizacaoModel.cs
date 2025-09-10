
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Domain.Models.Financeiro
{
    public class ParcelamentoAmortizacaoModel
    {
        public decimal ValorParcela { get; set; }
        public decimal ValorParcelaOriginal { get; set; }
        public int Parcela { get; set; }
        public decimal Amortizacao { get; set; }
        public decimal Juros { get; set; }
        public decimal SaldoInicialPeriodo { get; set; }
        public decimal SaldoFinalPeriodo { get; set; }
        public ValoresAdicionais ValoresAdicionais { get; set; }

    }
}
