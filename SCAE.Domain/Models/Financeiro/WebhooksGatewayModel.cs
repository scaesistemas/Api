using System;

namespace SCAE.Domain.Models
{
    public class WebhooksGatewayModel
    {
        public WebhookHokmaModel WebhookHokmaModel { get; set; }
        public WebhookCelcoinModel WebhookCelcoinModel { get; set; }
    }

    public class WebhookHokmaModel
    {
        public string BeneficiarioCodigo { get; set; }
        public string PaganteCodigo { get; set; }
        public string CpfPagante { get; set; }
        public string TipoPagamento { get; set; }
        public string Descricao { get; set; }
        public decimal ValorPago { get; set; }
        public string Status { get; set; }
        public string ReferenceId { get; set; }
    }

    public class WebhookCelcoinModel
    {
        public string BeneficiarioCodigo { get; set; }
        public string PaganteCodigo { get; set; }
        public string CpfPagante { get; set; }
        public string TipoPagamento { get; set; }
        public string Descricao { get; set; }
        public decimal ValorPago { get; set; }
        public string Status { get; set; }
        public string ReferenceId { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}