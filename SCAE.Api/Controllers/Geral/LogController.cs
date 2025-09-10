using SCAE.Domain.Entities.Geral;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Geral;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SCAE.Framework.Helper;
using System;
using SCAE.Framework.Exceptions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;
using SCAE.Service.Interfaces.Shared;
using SCAE.Domain.Models.Empreendimento.Relatorio;
using Microsoft.Extensions.Options;
using SCAE.Domain.Models.Shared;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace SCAE.Api.Controllers.Geral
{
    public class LogController : MasterQueryController<Log>
    {
        private readonly ILogService _service;
        private readonly ILoggerService _loggerService;
        private readonly LoggerSettingModel _loggerSettings;

        public LogController(ILogger<LogController> logger, ILogService service, ILoggerService loggerService, IOptions<LoggerSettingModel> loggerSettings) : base(logger, service)
        {
            _service = service;
            _loggerService = loggerService;
            _loggerSettings = loggerSettings.Value;
        }

        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Geral_Log_Listar)]
        public override ActionResult<PageResult<Log>> Get(ODataQueryOptions<Log> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Geral_Log_Listar)]
        public override Task<ActionResult<Log>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

        /// <response code="201"> Operação realizada com sucesso! </response>
        /// <response code="400"> Erros de validação do objeto. </response>
        /// <response code="500"> Algum erro o ocorreu! -> **Detalhamento da aplicação referente ao erro** </response>
        /// <param name="model"> Objeto com os dados a serem incluído. </param>
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [CheckPermission(Permissoes.Geral_Log_Cadastrar)]
        public async Task<ActionResult<Log>> Post([FromBody] Log model)
        {
            try
            {
                await _service.Post(model);

                return Created(string.Empty, model);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="200"> Operação realizada com sucesso! </response>
        /// <response code="400"> Erros de validação dos parâmetros. </response>
        /// <response code="500"> Algum erro ocorreu! -> **Detalhamento da aplicação referente ao erro** </response>
        /// <param name="dataHoraInicial"> Data e hora inicial para consulta. </param>
        /// <param name="dataHoraFinal"> Data e hora final para consulta. </param>
        /// <param name="assinanteId"> ID do assinante (opcional). </param>
        /// <param name="parcelaId"> ID da parcela (opcional). </param>
        /// <param name="transacaoId"> ID da transação (opcional). </param>
        /// <param name="erro"> Filtrar apenas erros (opcional). </param>
        /// <param name="isCobranca"> Filtrar logs de cobrança (opcional). </param>
        /// <param name="isBaixa"> Filtrar logs de baixa (opcional). </param>
        /// <param name="isEmissaoBoleto"> Filtrar logs de emissão de boleto (opcional). </param>
        /// <param name="isCancelamento"> Filtrar logs de cancelamento (opcional). </param>
        /// <param name="isCRM"> Filtrar logs de CRM (opcional). </param>
        [HttpGet("Financeiro/Cobranca")]
        [CheckPermission(Permissoes.Geral_Log_Listar)]
        public async Task<ActionResult<CobrancaModel>> GetCobranca(
            [FromQuery] string dataHoraInicial,
            [FromQuery] string dataHoraFinal,
            [FromQuery] int? assinanteId = null,
            [FromQuery] int? parcelaId = null,
            [FromQuery] int? transacaoId = null,
            [FromQuery] bool? erro = null,
            [FromQuery] bool? isCobranca = null,
            [FromQuery] bool? isBaixa = null,
            [FromQuery] bool? isEmissaoBoleto = null,
            [FromQuery] bool? isCancelamento = null,
            [FromQuery] bool? isCRM = null)
        {
            try
            {
                using (var client = GetClientLogger())
                {
                    var queryParams = new List<string>();
                    
                    if (!string.IsNullOrEmpty(dataHoraInicial))
                        queryParams.Add($"dataHoraInicial={Uri.EscapeDataString(dataHoraInicial)}");
                    
                    if (!string.IsNullOrEmpty(dataHoraFinal))
                        queryParams.Add($"dataHoraFinal={Uri.EscapeDataString(dataHoraFinal)}");
                    
                    if (assinanteId.HasValue)
                        queryParams.Add($"assinanteId={assinanteId.Value}");
                    
                    if (parcelaId.HasValue)
                        queryParams.Add($"parcelaId={parcelaId.Value}");
                    
                    if (transacaoId.HasValue)
                        queryParams.Add($"transacaoId={transacaoId.Value}");
                    
                    if (erro.HasValue)
                        queryParams.Add($"erro={erro.Value.ToString().ToLower()}");
                    
                    if (isCobranca.HasValue)
                        queryParams.Add($"isCobranca={isCobranca.Value.ToString().ToLower()}");
                    
                    if (isBaixa.HasValue)
                        queryParams.Add($"isBaixa={isBaixa.Value.ToString().ToLower()}");
                    
                    if (isEmissaoBoleto.HasValue)
                        queryParams.Add($"isEmissaoBoleto={isEmissaoBoleto.Value.ToString().ToLower()}");
                    
                    if (isCancelamento.HasValue)
                        queryParams.Add($"isCancelamento={isCancelamento.Value.ToString().ToLower()}");
                    
                    if (isCRM.HasValue)
                        queryParams.Add($"isCRM={isCRM.Value.ToString().ToLower()}");

                    var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
                    var response = await client.GetAsync($"Financeiro/Cobranca{queryString}");
                    var content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var cobrancas = JsonConvert.DeserializeObject<List<Cobranca>>(content);
                        var retorno = new CobrancaModel { cobrancas = cobrancas };
                        return Ok(retorno);
                    }
                    else
                    {
                        return BadRequest($"Erro ao consultar Logger-API: {content}");
                    }
                }
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        private HttpClient GetClientLogger()
        {
            var client = new HttpClient();
            var url = _loggerSettings.UrlBase;
#if (DEBUG)
            url = "http://localhost:5130/api/";
#endif
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
