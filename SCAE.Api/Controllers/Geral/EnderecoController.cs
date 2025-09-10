using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Api.Helpers;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Geral;
using System;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Geral
{
    [AllowAnonymous]
    [CustomAuthorize("admin,cliente")]
    public class EnderecoController : MasterBaseController
    {

        private readonly ILogger<EnderecoController> _logger;
        private readonly IEnderecoService _service;

        public EnderecoController(ILogger<EnderecoController> logger, IEnderecoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("Estado")]
        [CheckPermission(Permissoes.Geral_Endereco_Listar)]
        public ActionResult<PageResult<Estado>> ObterEstados(ODataQueryOptions<Estado> options)
        {
            try
            {
                var pageResult = GetPageResult(_service.ObterEstados(), options);

                return Ok(pageResult);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpGet("Estado/{id}")]
        [CheckPermission(Permissoes.Geral_Endereco_Listar)]
        public async Task<ActionResult<Estado>> ObterEstadoPorId(int id)
        {
            try
            {
                var estado = await _service.ObterEstado(id);

                if (estado == null)
                    return NotFound(MensagemHelper.RegistroNaoEncontrato);

                return Ok(estado);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpGet("Estado/{estadoId}/Municipio")]
        [CheckPermission(Permissoes.Geral_Endereco_Listar)]
        public ActionResult<PageResult<Municipio>> ObterMunicipios(int estadoId, ODataQueryOptions<Municipio> options)
        {
            try
            {
                var pageResult = GetPageResult(_service.ObterMunicipios(estadoId), options);

                return Ok(pageResult);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpGet("Estado/Municipio/{id}")]
        [CheckPermission(Permissoes.Geral_Endereco_Listar)]
        public async Task<ActionResult<Municipio>> ObterMunicipioPorId(int id)
        {
            try
            {
                var municipio = await _service.ObterMunicipio(id);

                if (municipio == null)
                    return NotFound(MensagemHelper.RegistroNaoEncontrato);

                return Ok(municipio);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpGet("Cep/{cep}")]
        [CheckPermission(Permissoes.Geral_Endereco_Listar)]
        public async Task<ActionResult<EnderecoModel>> ObterPorCep(string cep)
        {
            try
            {
                var endereco = await _service.ObterPorCep(cep);

                if(endereco == null)
                    return NotFound(MensagemHelper.RegistroNaoEncontrato);

                return Ok(endereco);
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
