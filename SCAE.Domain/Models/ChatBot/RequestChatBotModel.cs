using Newtonsoft.Json;

namespace SCAE.Domain.Models.ChatBot
{
    public class RequestChatBotModel
    {
        public int Id { get; set; }
        [JsonProperty("text")] public string Texto { get; set; }
        [JsonProperty("contact")] public Contato Contato { get; set; }
        [JsonProperty("data")] public DadosAdicionais DadosAdicionais { get; set; }

    }

    public class Contato
    {
        [JsonProperty("uid")] public int ContatoId { get; set; }
        [JsonProperty("type")] public string Tipo { get; set; }
        [JsonProperty("key")] public string NumeroContato { get; set; }
        [JsonProperty("name")] public string NomeContato { get; set; }
        [JsonProperty("fields")] public CamposSegmentacao Campos { get; set; }

    }

    public class CamposSegmentacao
    {
        [JsonProperty("cpf")] public string CPF { get; set; }

    }

    public class DadosAdicionais
    {
        [JsonProperty("dataValue")] public string Dados { get; set; }
        [JsonProperty("contrato")] public int IdContrato { get; set; }
        [JsonProperty("subscriberNumber")] public int IdAssinante { get; set; }
    }
}
