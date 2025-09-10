using Newtonsoft.Json;
using System;

namespace SCAE.Domain.Models.Zoop
{
    public class SellerIndividualModel
    {
        public string Id { get; set; }
        [JsonProperty("taxpayer_id")] public string Cpf { get; set; }
        [JsonProperty("first_name")] public string Nome { get; set; }
        [JsonProperty("last_name")] public string SobreNome { get; set; }
        [JsonProperty("phone_number")] public string Telefone { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("mcc")] public string Categoria { get; set; }
        [JsonProperty("address")] public AddressModel Endereco { get; set; }
        [JsonProperty("birthdate")] public DateTime DataNascimento { get; set; }

        public SellerIndividualModel()
        {
            Endereco = new AddressModel();
        }
    }
}
