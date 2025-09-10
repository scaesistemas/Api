using Newtonsoft.Json;

namespace SCAE.Domain.Models.GalaxPay
{
    public class AddressModel
    {
       [JsonProperty("zipCode")] public string Cep { get; set; }
       [JsonProperty("street")] public string Logradouro { get; set; }
       [JsonProperty("number")] public string Numero { get; set; }
       [JsonProperty("complement")] public string Complemento { get; set; }
       [JsonProperty("neighborhood")] public string Bairro { get; set; }
       [JsonProperty("city")] public string Cidade { get; set; }
       [JsonProperty("state")] public string Estado { get; set; }


    }
}
