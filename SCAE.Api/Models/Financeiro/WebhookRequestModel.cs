namespace SCAE.Api.Models.Financeiro
{
    public class WebhookRequestHokmaModel
    {
        public string SellerId { get; set; }
        public string BuyerId { get; set; }
        public string PayerDocument { get; set; }
        public int PaymentWay { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Status { get; set; }
        public string ReferenceId { get; set; }
    }
    
}