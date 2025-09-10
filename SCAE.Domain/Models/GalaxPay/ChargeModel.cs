using Newtonsoft.Json;
using System;

namespace SCAE.Domain.Models.GalaxPay
{
    public class ChargeModel
    {
        [JsonProperty("myId")] public string ParcelaId { get; set; }
        [JsonProperty("value")] public int Valor { get; set; }
        [JsonProperty("payday")] public string Vencimento { get; set; }
        [JsonProperty("mainPaymentMethodId")] public string MetodoPagamento { get; set; }
        [JsonProperty("Customer")] public CustomerResume Cliente { get; set; }
        [JsonProperty("PaymentMethodBoleto")] public PaymentMethodBoleto ConfiguracoesBoleto { get; set; }
        [JsonProperty("Discount")] public Discount Desconto { get; set; }
        public ChargeModel()
        {
            MetodoPagamento= "boleto";
            Cliente= new CustomerResume();
            ConfiguracoesBoleto= new PaymentMethodBoleto();
        }

    }

    public class CustomerResume
    {
        [JsonProperty("myId")] public string Id { get; set; }
    }

    public class Discount
    {
        [JsonProperty("qtdDaysBeforePayDay")] public int  DiasDescontoVencimento { get; set; }
        [JsonProperty("type")] public string Tipo { get; set; }
        [JsonProperty("value")] public int Porcentagem { get; set; }
    }

    public class PaymentMethodBoleto
    {
        [JsonProperty("fine")] public int Multa { get; set; }
        [JsonProperty("interest")] public int Juros { get; set; }
        [JsonProperty("instructions")] public string Instrucoes { get; set; }
        [JsonProperty("deadlineDays")] public int DiasPosVencimento { get; set; }
    }
}
