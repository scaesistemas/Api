using System;

namespace SCAE.Api.Models.Financeiro
{
    public class BradescoRespostaWebhookModel
    {
        public string TipoEvento { get; set; }
        public int Produto { get; set; }
        public long Negociacao { get; set; }
        public long NossoNumero { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorBoleto { get; set; }
        public int BancoRecebedor { get; set; }
        public int CanalPagamento { get; set; }
        public DateTime DataPagamento { get; set; }

        /// <summary>
        /// HoraPagamento representada no formato HHMMSS (Ex: 140608 = 14:06:08)
        /// </summary>
        public int HoraPagamento { get; set; }

        public decimal ValorPagamento { get; set; }

        public TimeSpan HoraPagamentoTimeSpan =>
            TimeSpan.TryParseExact(HoraPagamento.ToString("D6"), "hhmmss", null, out var result) ? result : TimeSpan.Zero;

    }
}