using Microsoft.Extensions.Options;
using SCAE.Domain.Models.Shared;
using SCAE.Service.Interfaces.Shared;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using SCAE.Framework.Exceptions;
using System.IO;
using System.Linq;

namespace SCAE.Service.Services.Shared
{
    public class SmsService : ISmsService
    {
        private readonly SmsSettingModel _appSettings;

        public SmsService(IOptions<SmsSettingModel> settings)
        {
            _appSettings = settings.Value;
        }

        private HttpClient GetCabecalho()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_appSettings.UrlBase);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public string GerarCorpoCobranca(int layoutId, string clienteNome, string dataVencimento, string contratoNumero,string linhaDigitavel, string linkBoleto, string dominio, string empresaNome, string empresaNumero, string empresaEmail)
        {
            var body = string.Empty;

            using (var reader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Template/Cobranca/TemplateSms{layoutId:D2}.txt"))
            {
                body = reader.ReadToEnd();
                body = body.Replace("$cliente_nome$", clienteNome.Split(" ").FirstOrDefault());
                body = body.Replace("$dataVencimento$", dataVencimento);
                body = body.Replace("$contrato_numero$", contratoNumero);
                body = body.Replace("$linha_digitavel$", linhaDigitavel);
                body = body.Replace("$link_boleto$", linkBoleto);
                body = body.Replace("cliente-$subDominio_nome$.scae.adm.br", dominio);
                body = body.Replace("$empresa_nome$", empresaNome);
                body = body.Replace("$empresa_numero$", empresaNumero);
                body = body.Replace("$empresa_email$", empresaEmail);

            }

            return body;
        }

        public async Task EnviarSms(string NumerosDestinatarios, string texto)
        {
            using (var client = GetCabecalho())
            {
                var model = new
                {
                    token = _appSettings.Token,
                    numbers = NumerosDestinatarios,
                    content = texto,
                    type_service = "SHORTCODE"
                };

                var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync("send", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                    throw new BadRequestException(data.message);
            }
        }
    }
}