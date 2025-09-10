using Newtonsoft.Json;
using System.Collections.Generic;

namespace SCAE.Domain.Models.GalaxPay
{
    public class ChargeReturnModel
    {

        [JsonProperty("totalQtdFoundInPage")]
        public int TotalQtdFoundInPage { get; set; }

        [JsonProperty("Charges")]
        public List<ChargeReturnInformationModel> Charges { get; set; }
    }

    public class ChargeReturnInformationModel
    {
        [JsonProperty("myId")]
        public string Id { get; set; }

        [JsonProperty("planMyId")]
        public string PlanMyId { get; set; }

        [JsonProperty("mainPaymentMethodId")]
        public string MainPaymentMethodId { get; set; }

        [JsonProperty("paymentLink")]
        public string LinkPagamento { get; set; }

        [JsonProperty("additionalInfo")]
        public string InformacoesAdicionais { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("payedOutsideGalaxPay")]
        public bool PagamentoForaGalaxPay { get; set; }

        [JsonProperty("Transactions")]
        public List<TransactionReturnModel> Transacoes { get; set; }

        [JsonProperty("PaymentMethodBoleto")]
        public PaymentMethodBoleto PaymentMethodBoleto { get; set; }

    }

    public class TransactionReturnModel
    {
        [JsonProperty("myId")]
        public string Id { get; set; }

        [JsonProperty("value")]
        public int Valor { get; set; }

        [JsonProperty("payday")]
        public string Vencimento { get; set; }

        [JsonProperty("installment")]
        public int Installment { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("fee")]
        public int TaxaPaga { get; set; }

        [JsonProperty("statusDescription")]
        public string DescricaoStatus { get; set; }

        [JsonProperty("reasonDenied")]
        public string MotivoNegacao { get; set; }

        [JsonProperty("Boleto")]
        public BoletoReturnModel Boleto { get; set; }
        public bool Pago => Status == "paid";

    }

    public class BoletoReturnModel
    {
        [JsonProperty("pdf")]
        public string Pdf { get; set; }

        [JsonProperty("bankLine")]
        public string BankLine { get; set; }

        [JsonProperty("bankAgency")]
        public string BankAgency { get; set; }

        [JsonProperty("bankAccount")]
        public string BankAccount { get; set; }
    }


}

