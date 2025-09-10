using Newtonsoft.Json;

namespace SCAE.Domain.Models.Zoop
{
    public class PersonModel
    {
        [JsonProperty("taxpayer_id")] public string Cpf { get; set; }
        [JsonProperty("first_name")] public string Nome { get; set; }
        [JsonProperty("last_name")] public string Sobrenome { get; set; }
        [JsonProperty("phone_number")] public string Telefone { get; set; }
        [JsonProperty("birthdate")] public string DataNascimento { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
    }
}
