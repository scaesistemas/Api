using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Zoop
{
    public class TransactionModel
    {
        public string Id { get; set; }
        [JsonProperty("amount")] public int Valor { get; set; }
        [JsonProperty("currency")] public string Moeda { get; set; }
        [JsonProperty("description")] public string Descricao { get; set; }
        [JsonProperty("payment_type")] public string Tipo { get; set; }
        [JsonProperty("reference_id")] public string ReferenciaId { get; set; }
        [JsonProperty("on_behalf_of")] public string SellerId { get; set; }
        [JsonProperty("customer")] public string BuyerId { get; set; }
        [JsonProperty("payment_method")] public PaymentMethodModel Metodo { get; set; }
        [JsonProperty("metadata")] public MetaDataModel Adicional { get; set; }
        [JsonProperty("history")] public List<HistoryModel> Historicos { get; set; }

        public TransactionModel()
        {
            Moeda = "BRL";
            Tipo = "boleto";

            Metodo = new PaymentMethodModel();
        }
    }

    public class TransactionReturnModel
    {
        public string Id { get; set; }
        [JsonProperty("amount")] public decimal Valor { get; set; }
        [JsonProperty("currency")] public string Moeda { get; set; }
        [JsonProperty("description")] public string Descricao { get; set; }
        [JsonProperty("payment_type")] public string Tipo { get; set; }
        [JsonProperty("reference_id")] public string ReferenciaId { get; set; }
        [JsonProperty("on_behalf_of")] public string SellerId { get; set; }
        [JsonProperty("customer")] public string BuyerId { get; set; }
        [JsonProperty("payment_method")] public PaymentMethodModel Metodo { get; set; }
        [JsonProperty("metadata")] public MetaDataModel Adicional { get; set; }
        [JsonProperty("history")] public List<HistoryModel> Historicos { get; set; }

        public TransactionReturnModel()
        {
            Moeda = "BRL";
            Tipo = "boleto";

            Metodo = new PaymentMethodModel();
        }
    }

    public class MetaDataModel
    {
        [JsonProperty("bank_id")] public string CodigoBancoEmitente { get; set; }
        [JsonProperty("bank_id_paid")] public string CodigoBancoPagador { get; set; }
        [JsonProperty("payment_date")] public DateTime DataPagamento { get; set; }
    }

    public class PaymentMethodModel
    {
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("expiration_date")] public DateTime DataVencimento { get; set; }
        [JsonProperty("payment_limit_date")] public DateTime? DataLimite { get; set; }
        //[JsonProperty("body_instructions")] public string[] Instrucoes { get; set; }
        [JsonProperty("billing_instructions")] public BillingInstructionModel IntrucaoCobranca { get; set; }
        [JsonProperty("body_instructions")] public List<string> Instrucoes { get; set; }

        public PaymentMethodModel()
        {
            IntrucaoCobranca = new BillingInstructionModel();
            Instrucoes = new List<string>();
        }
    }

    public class BillingInstructionModel
    {
        [JsonProperty("late_fee")] public JurosMultaModel Multa { get; set; }
        [JsonProperty("interest")] public JurosMultaModel Juros { get; set; }
        [JsonProperty("discount")] public List<DescontoModel> Descontos { get; set; }

        public BillingInstructionModel()
        {
            Multa = new JurosMultaModel() { Modo = "PERCENTAGE" };
            Juros = new JurosMultaModel() { Modo = "DAILY_PERCENTAGE" };
        }
    }

    public class JurosMultaModel
    {
        [JsonProperty("mode")] public string Modo { get; set; }
        [JsonProperty("percentage")] public decimal Porcentagem { get; set; }
    }

    public class DescontoModel
    {
        [JsonProperty("mode")] public string Modo { get; set; }
        [JsonProperty("percentage")] public decimal Porcentagem { get; set; }
        [JsonProperty("limit_date")] public DateTime DataLimite { get; set; }
    }

    public class HistoryModel
    {
        public string Id { get; set; }
        [JsonProperty("created_at")] public DateTime Data { get; set; }
        [JsonProperty("amount")] public decimal Valor { get; set; }
        [JsonProperty("operation_type")] public string Tipo { get; set; }
        public bool Pago => Tipo == "paid";
    }
}
