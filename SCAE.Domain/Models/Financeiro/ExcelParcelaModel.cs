using System;

namespace SCAE.Domain.Models.Financeiro
{
    public class ExcelParcelaModel
    {
        public string QuadraLote { get; set; }
        public int Pago { get; set; }
        public decimal SaldoComecoPeriodo { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal Amortizacao { get; set; }
        public decimal CorrecaoIndice { get; set; }
        public decimal Juros { get; set; }
        public decimal MPI { get; set; }
        public decimal DFI { get; set; }
        public decimal Gestao { get; set; }
        public decimal CorrecaoSaldo { get; set; }
        public decimal SaldoFimMesCorrigido { get; set; } 
        public DateTime DataPagamento { get; set; }
        public decimal ValorPago { get; set; }
        public decimal Multa { get; set; }


        public int NumeroParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Quadra => !string.IsNullOrEmpty(QuadraLote) ? QuadraLote.Substring(QuadraLote.IndexOf("Q") + 1,2) : "";
        public string Lote => !string.IsNullOrEmpty(QuadraLote) ? QuadraLote.Substring(QuadraLote.IndexOf("L") + 1) : "";

    }
}
