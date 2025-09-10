using Newtonsoft.Json;

namespace SCAE.Domain.Models.Clientes.ContratoDigitalNS
{
    public class SafeModel
    {
       [JsonProperty("uuid-safe")]public string TesteId { get; set; }
       [JsonProperty("name-safe")]public string Nome { get; set; }
    }
}
