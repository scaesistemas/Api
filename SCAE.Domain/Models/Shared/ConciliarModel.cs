using SCAE.Domain.Entities.Financeiro;
using System;

namespace SCAE.Domain.Models.Shared
{
    public class ConciliarModel
    {
        public int ParcelaId { get; set; }
        public int? BaixaId { get; set; }
        public decimal ValorBaixa { get; set; }
        public string FitId { get; set; }
        public DateTime Data { get; set; }
        public bool Conciliado { get; set; }
        public int FormaPagamentoId { get; set; }
    }
}
