using Microsoft.Extensions.Options;
using SCAE.Domain.Models.Shared;
using SCAE.Service.Interfaces.Shared;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;

namespace SCAE.Service.Services.Shared
{
    public class LoggerService : ILoggerService
    {
        private readonly LoggerSettingModel _appSettings;
        public LoggerService(IOptions<LoggerSettingModel> settings)
        {
            _appSettings = settings.Value;
        }

        private HttpClient GetCabecalho()
        {
            var client = new HttpClient();
            var url = _appSettings.UrlBase;
#if (DEBUG)
            url = "http://localhost:5130/api/";
#endif
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public async Task EnviarWorker(int assinanteId, int parcelaId, int transacaoId, string descricao, bool isErro, ILogger logger, bool isCobranca = false, bool isBaixa = false, bool isEmissaoBoleto = false, bool isCancelamento = false, bool isCRM = false)
        {
            try
            {
                using (var client = GetCabecalho())
                {
                    var model = new
                    {
                        AssinanteId = assinanteId,
                        ParcelaId = parcelaId,
                        TransacaoId = transacaoId,
                        Descricao = descricao,
                        Erro = isErro,
                        IsCobranca = isCobranca,
                        IsBaixa = isBaixa,
                        IsEmissaoBoleto = isEmissaoBoleto,
                        IsCancelamento = isCancelamento,
                        IsCRM = isCRM
                    };

                    var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    stringContent.Headers.ContentType.Parameters.Clear();
                    var response = await client.PostAsync("Financeiro/Cobranca", stringContent);
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(content);

                    if (!response.IsSuccessStatusCode)
                    {
                        logger.LogError($"ERRO AO SALVAR LOG: {data}");
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogError($"ERRO AO SALVAR LOG: {e.Message} {(e.InnerException != null ? $" - {e.InnerException.Message}" : "")}");
            }
        }
    }
}
