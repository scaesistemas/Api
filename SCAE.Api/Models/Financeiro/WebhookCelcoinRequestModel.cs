using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SCAE.Api.Models.Financeiro
{
    public class WebhookCelcoinRequestModel
     {
        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("webhookId")]
        public long WebhookId { get; set; }

        [JsonPropertyName("confirmHash")]
        public string ConfirmHash { get; set; }

        [JsonPropertyName("Transaction")]
        public TransactionData Transaction { get; set; }

        [JsonPropertyName("Charge")]
        public ChargeData Charge { get; set; }
    }

    public class TransactionData
    {
        [JsonPropertyName("myId")]
        public string MyId { get; set; }

        [JsonPropertyName("galaxPayId")]
        public long GalaxPayId { get; set; }

        [JsonPropertyName("chargeMyId")]
        public string ChargeMyId { get; set; }

        [JsonPropertyName("chargeGalaxPayId")]
        public long ChargeGalaxPayId { get; set; }

        [JsonPropertyName("subscriptionMyId")]
        public string SubscriptionMyId { get; set; }

        [JsonPropertyName("subscriptionGalaxPayId")]
        public long SubscriptionGalaxPayId { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }

        [JsonPropertyName("payday")]
        public string Payday { get; set; }

        [JsonPropertyName("fee")]
        public long Fee { get; set; }

        [JsonPropertyName("payedOutsideGalaxPay")]
        public bool PayedOutsideGalaxPay { get; set; }

        [JsonPropertyName("additionalInfo")]
        public string AdditionalInfo { get; set; }

        [JsonPropertyName("installment")]
        public long Installment { get; set; }

        [JsonPropertyName("paydayDate")]
        public string PaydayDate { get; set; }

        [JsonPropertyName("AbecsReasonDenied")]
        public AbecsReasonDenied AbecsReasonDenied { get; set; }

        [JsonPropertyName("datetimeLastSentToOperator")]
        public string DatetimeLastSentToOperator { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("tid")]
        public string Tid { get; set; }

        [JsonPropertyName("authorizationCode")]
        public string AuthorizationCode { get; set; }

        [JsonPropertyName("reasonDenied")]
        public string ReasonDenied { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("Boleto")]
        public BoletoData Boleto { get; set; }

        [JsonPropertyName("Pix")]
        public PixData Pix { get; set; }
    }

    public class AbecsReasonDenied
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public class BoletoData
    {
        [JsonPropertyName("pdf")]
        public string Pdf { get; set; }

        [JsonPropertyName("bankLine")]
        public string BankLine { get; set; }
    }

    public class PixData
    {
        [JsonPropertyName("qrCode")]
        public string QrCode { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("page")]
        public string Page { get; set; }

        [JsonPropertyName("endToEndId")]
        public string EndToEndId { get; set; }
    }

    public class ChargeData
    {
        [JsonPropertyName("galaxPayId")]
        public long GalaxPayId { get; set; }

        [JsonPropertyName("myId")]
        public string MyId { get; set; }

        [JsonPropertyName("mainPaymentMethodId")]
        public string MainPaymentMethodId { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("additionalInfo")]
        public string AdditionalInfo { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("Customer")]
        public CustomerData Customer { get; set; }

        [JsonPropertyName("PaymentMethodCreditCard")]
        public PaymentMethodCreditCardData PaymentMethodCreditCard { get; set; }

        [JsonPropertyName("PaymentMethodBoleto")]
        public PaymentMethodBoletoData PaymentMethodBoleto { get; set; }

        [JsonPropertyName("PaymentMethodPix")]
        public PaymentMethodPixData PaymentMethodPix { get; set; }
    }

    public class CustomerData
    {
        [JsonPropertyName("galaxPayId")]
        public long GalaxPayId { get; set; }

        [JsonPropertyName("myId")]
        public string MyId { get; set; }

        [JsonPropertyName("phones")]
        public long[] Phones { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("document")]
        public string Document { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("Address")]
        public AddressData Address { get; set; }
    }

    public class AddressData
    {
        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("complement")]
        public string Complement { get; set; }

        [JsonPropertyName("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }
    }

    public class PaymentMethodCreditCardData
    {
        [JsonPropertyName("Card")]
        public CardData Card { get; set; }
    }

    public class CardData
    {
        [JsonPropertyName("galaxPayId")]
        public long GalaxPayId { get; set; }

        [JsonPropertyName("myId")]
        public string MyId { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("expiresAt")]
        public string ExpiresAt { get; set; }
    }

    public class PaymentMethodBoletoData
    {
        [JsonPropertyName("fine")]
        public long Fine { get; set; }

        [JsonPropertyName("interest")]
        public long Interest { get; set; }

        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }
    }

    public class PaymentMethodPixData
    {
        [JsonPropertyName("fine")]
        public long Fine { get; set; }

        [JsonPropertyName("interest")]
        public long Interest { get; set; }

        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }

        [JsonPropertyName("Deadline")]
        public DeadlineData Deadline { get; set; }
    }

    public class DeadlineData
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}