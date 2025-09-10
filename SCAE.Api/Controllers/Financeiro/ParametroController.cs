using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway;

namespace SCAE.Api.Controllers.Financeiro
{
    [Route("api/financeiro/[controller]")]
    public class ParametroController : MasterCrudController<Parametro>
    {
        private readonly IParametroService _service;
        public ParametroController(ILogger<ParametroController> logger, IParametroService service) : base(logger, service, "Gatways.ContasCorrentesSplit, Gatways,Cobrancas,ParametroCRMVendas")
        {
            _service = service;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_Parametro_Cadastrar)]
        public override Task<ActionResult<Parametro>> Post([FromBody] Parametro model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_Parametro_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Parametro> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_Parametro_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Parametro model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_Parametro_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Financeiro_Parametro_Listar)]
        public override ActionResult<PageResult<Parametro>> Get(ODataQueryOptions<Parametro> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_Parametro_Listar)]
        public override Task<ActionResult<Parametro>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

        [HttpGet("{empresaId}/First")]
        [AllowAnonymous]
        public async Task<ActionResult<Parametro>> GetFirst(int empresaId)
        {
            try
            {
                var domain = await _service.GetFirst(empresaId);

                if (domain == null)
                    return NotFound(MensagemHelper.RegistroNaoEncontrato);

                return Ok(domain);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpGet("Gateway/{gatewayId}")]
        [CheckPermission(Permissoes.Financeiro_Parametro_Listar)]
        public async Task<ActionResult<ParametroGatway>> GetGatewayById(int gatewayId)
        {
            try
            {
                var domain = await _service.GetGatewayByIdNoInclude(gatewayId);

                if (domain == null)
                    return NotFound(MensagemHelper.RegistroNaoEncontrato);

                return Ok(domain);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpPut("{cobrancaId}/EnviarSms")]
        [CheckPermission(Permissoes.Financeiro_Parametro_EnviarSMS)]
        public async Task<IActionResult> EnviarSms(int cobrancaId, bool enviarSms)
        {
            try
            {
                await _service.EnviarSms(cobrancaId, enviarSms);

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpPut("{gatewayId}/GatewayPrincipal")]
        [CheckPermission(Permissoes.Financeiro_Parametro_Alterar)]
        public async Task<IActionResult> DefinirGatewayPrincipal(int gatewayId)
        {
            try
            {
                await _service.DefinirGatewayPrincipal(gatewayId);

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpPost("CriarSubConta/{id}")]
        [CheckPermission(Permissoes.Financeiro_Parametro_Cadastrar)]
        public async Task<IActionResult> GerarSubConta(int id, [FromQuery] int tipoGatewayId, [FromBody] SubContaModel subcontaModel)
        {
            try
            {
                await _service.CriarSubConta(id, tipoGatewayId, subcontaModel);

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (NotFoundException e)
            
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpPost("EnviarDocumentoSubconta/{id}")]
        [CheckPermission(Permissoes.Financeiro_Parametro_Cadastrar)]
        public async Task<IActionResult> EnviarDocumentoSubconta(int id, [FromQuery] int tipoGatewayId, [FromBody] SubcontaDocumentoScaeModel documentos)
        {
            try
            {
                await _service.EnviarDocumentoSubconta(id, tipoGatewayId, documentos);

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }
        
        [HttpGet("VerificarSubconta/{id}")]
        [CheckPermission(Permissoes.Financeiro_Parametro_Cadastrar)]
        public async Task<ActionResult<SubcontaConsultaModel>> ConsultarSubconta(int id, [FromQuery] int tipoGatewayId)
        {
            try
            {
                var retorno = await _service.ConsultarSubconta(id, tipoGatewayId);

                return Ok(retorno);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }
    }
}
