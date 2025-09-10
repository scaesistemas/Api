using Newtonsoft.Json;

namespace SCAE.Domain.Models.Zoop
{
    public class AddressModel
    {
        [JsonProperty("line1")] public string Logradouro { get; set; }
        [JsonProperty("line2")] public string Numero { get; set; }
        [JsonProperty("line3")] public string Complemento { get; set; }
        [JsonProperty("neighborhood")] public string Bairro { get; set; }
        [JsonProperty("city")] public string Cidade { get; set; }
        [JsonProperty("state")] public string Estado { get; set; }
        [JsonProperty("postal_code")] public string Cep { get; set; }
        [JsonProperty("country_code")] public string Pais { get; set; }

        public AddressModel()
        {
            Pais = "BR";
        }
    }
}
