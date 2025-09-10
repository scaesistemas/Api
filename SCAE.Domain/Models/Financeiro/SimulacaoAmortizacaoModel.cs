namespace SCAE.Domain.Models.Financeiro
{
    public class SimulacaoAmortizacaoModel
    {
        public decimal SaldoAmortizacaoAtual { get; set; }
        public decimal SaldoAmortizacaoNovo { get; set; }
        public decimal ValorAmortizado { get; set; }
        public decimal ValorParcelaAtual { get; set; }
        public decimal ValorParcelaNovo { get; set; }
        public decimal ValorReduzidoParcela { get; set; }
        public int QuantidadeParcelasAtual { get; set; }
        public int QuantidadeParcelasNovo { get; set; }
        public int QuantidadeParcelasAmortizadas { get; set; }

    }
}
