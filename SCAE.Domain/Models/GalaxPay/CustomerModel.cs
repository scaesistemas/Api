using Newtonsoft.Json;
using System.Collections.Generic;

namespace SCAE.Domain.Models.GalaxPay
{
    public class CustomerModel
    {
        [JsonProperty("myId")] public string Id { get; set; }
        [JsonProperty("name")] public string Nome { get; set; }
        [JsonProperty("document")] public string CpfCnpj { get; set; }
        [JsonProperty("emails")] public List<string> Emails { get; set; }
        [JsonProperty("phones")] public List<long> Telefones { get; set; }
        [JsonProperty("Address")] public AddressModel Address { get; set; }

        public CustomerModel()
        {
            Address = new AddressModel();
            Emails = new List<string>();
            Telefones = new List<long>();
        }
    }
}
