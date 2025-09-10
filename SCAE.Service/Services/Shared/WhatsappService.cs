using DFe.Classes;
using DocumentFormat.OpenXml;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SCAE.Domain.Models.Shared;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Shared
{
    public class WhatsappService: IWhatsappService
    {
        private readonly HttpClient _httpClient;
        private const string ApiEndpoint = "https://api.zixflow.com/api/v1/";
        private const string Token = "f6e424f6e434b9fe7f68bd29d1d9406dbb7ce64350ebae04bc151c366848525db5c8c57671b3535b";
        private const string PhoneId = "706330739222975";

        public WhatsappService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> EnviarMensagem(MessageWhatsappModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _httpClient.PostAsync(ApiEndpoint + "campaign/whatsapp/send", stringContent);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException httpEx)
            {
                return $"Erro ao envicar mensagem - HTTP Error: {httpEx.Message}";
            }
            catch (Exception ex)
            {
                return $"Erro ao enviar mensagem: {ex.Message}";
            }
        }
        public MessageWhatsappModel GerarMensagem(string phone, string nome, decimal valor, DateTime dataVencimento, string urlBoleto, int numeroParcela, string nomeEmpresa, string contrato)
        {
            string telefone = StringHelper.LimparTelefone(phone);

            if (telefone.StartsWith("+55"))
            {
                telefone = telefone.Substring(1);
            }

            if (!telefone.StartsWith("55"))
            {
                telefone = "55" + telefone;
            }
            var body = new MessageWhatsappModel
            {
                To = telefone,
                PhoneId = PhoneId,
                Language = "pt_BR",
                TemplateName = "payment_with_link6",
                Variables = new VariablesZix
                {
                    Body_1 = nome,
                    Body_2 = valor.ToString(),
                    Body_3 = $"{dataVencimento.ToString("dd/MM/yyyy")}",
                    Body_4 = numeroParcela.ToString(),
                    Body_5 = contrato,
                    Body_6 = nomeEmpresa,
                    Body_7 = urlBoleto,
                },
                SubmissionStatus = false
            };
            return body;
        }

        public MessageWhatsappModel GerarMensagem(string phone, string nome, decimal valor, DateTime dataVencimento, string linhaDigitavel, string qrcode, int numeroParcela, string nomeEmpresa, string contrato)
        {
            string telefone = StringHelper.LimparTelefone(phone);

            if (telefone.StartsWith("+55"))
            {
                telefone = telefone.Substring(1);
            }
            
            if (!telefone.StartsWith("55"))
            {
                telefone = "55" + telefone;
            }
            var body = new MessageWhatsappModel
            {
                To = telefone,
                PhoneId = PhoneId,
                Language = "pt_BR",
                TemplateName = "payment_with_digitable_line2",
                Variables = new VariablesZix
                {
                    Body_1 = nome,
                    Body_2 = valor.ToString(),
                    Body_3 = $"{dataVencimento.ToString("dd/MM/yyyy")}",
                    Body_4 = numeroParcela.ToString(),
                    Body_5 = contrato,
                    Body_6 = nomeEmpresa,
                    Body_7 = qrcode,
                    Body_8 = linhaDigitavel
                },
                SubmissionStatus = false
            };
            return body;
        }
    }
}
