using Newtonsoft.Json;

namespace SCAE.Domain.Models.Zoop
{
    public class SellerModel
    {
        public string Id { get; set; }
        [JsonProperty("ein")] public string Cnpj { get; set; }
        [JsonProperty("business_name")] public string Nome { get; set; }
        [JsonProperty("business_phone")] public string Telefone { get; set; }
        [JsonProperty("business_email")] public string Email { get; set; }
        [JsonProperty("mcc")] public string Categoria { get; set; }
        [JsonProperty("business_address")] public AddressModel Endereco { get; set; }
        [JsonProperty("owner")] public PersonModel Proprietario { get; set; }
        [JsonProperty("owner_address")] public AddressModel ProprietarioEndereco { get; set; }

        public SellerModel()
        {
            Endereco = new AddressModel();
            Proprietario = new PersonModel();
            ProprietarioEndereco = new AddressModel();
        }
    }
}
