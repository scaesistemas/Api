using Newtonsoft.Json;

namespace SCAE.Domain.Models.Zoop
{
    public class BuyerModel
    {
        public string Id { get; set; }
        [JsonProperty("taxpayer_id")] public string CpfCnpj { get; set; }
        [JsonProperty("first_name")] public string Nome { get; set; }
        [JsonProperty("last_name")] public string UltimoNome { get; set; }
        [JsonProperty("phone_number")] public string Telefone { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("address")] public AddressModel Endereco { get; set; }

        public BuyerModel()
        {
            Endereco = new AddressModel();
        }
    }
}
