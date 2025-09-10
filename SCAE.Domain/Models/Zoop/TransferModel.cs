using Newtonsoft.Json;

namespace SCAE.Domain.Models.Zoop
{
    public class TransferModel
    {
        [JsonProperty("amount")] public int Valor { get; set; }
        [JsonProperty("statement_descriptor")] public string Identificacao { get; set; }
        [JsonProperty("description")] public string Descricao { get; set; }
    }
}
