using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Clientes.ContratoDigitalNS
{
    public class SignerModel
    {
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("act")] public string TipoAssinaturaId { get; set; }
        [JsonProperty("foreign")] public string Estrangeiro { get; set; }
        [JsonProperty("certificadoicpbr")] public string CertificadoICPBR { get; set; }
        [JsonProperty("assinatura_presencial")] public string AssinaturaPresencial { get; set; }
    }

    public class ResponseKeySignerModel
    {
        [JsonProperty("key_signer")] public string KeySigner { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
    }

    public class RemoverSignatarioModel
    {
        [JsonProperty("email-signer")] public string Email { get; set; }
        [JsonProperty("key-signer")] public string KeySigner { get; set; }
    }

}
