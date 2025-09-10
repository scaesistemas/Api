

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Api.Helpers;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Geral;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Base;
using SCAE.Service.Interfaces.Development;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Base
{
    public class AssinanteController : MasterCrudController<Assinante>
    {
        private readonly IAssinanteService _service;
        private readonly IApiDevelopmentService _developmentService;
        public AssinanteController(ILogger<AssinanteController> logger, IAssinanteService service, IApiDevelopmentService developmentService) : base(logger, service)
        {
            _service = service;
            _developmentService = developmentService;
        }

        [HttpPost]
        [AllowAnonymous]
        public override Task<ActionResult<Assinante>> Post([FromBody] Assinante assinante)
        {
            return base.Post(assinante);
        }

        [HttpGet("Development")]
        [CheckPermission(Permissoes.Financeiro_Indice_Listar)]
        public async Task<ActionResult<PageResult<Assinante>>> GetAssinante()
        {
            try
            {
                var lista = await _developmentService.GetAssinante();
                var pageResult = new PageResultModel<Assinante>() { Items = lista, Count = lista.Count };
                return Ok(pageResult);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpGet("Ativos")]
        [CheckPermission(Permissoes.Base_Assinante_Listar)]
        public async Task<ActionResult<List<Assinante>>> GetAssinantesAtivos()
        {
            try
            {
                var lista = await _service.GetAllNoTracking().Where(a => a.Ativo).ToListAsync();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpGet("{id}/Development")]
        [CheckPermission(Permissoes.Financeiro_Indice_Listar)]
        public async Task<ActionResult<Assinante>> GetAssinante(int id)
        {
            try
            {
                var assinante = await _developmentService.GetAssinanteById(id);
                return Ok(assinante);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpGet("{id}/WhatsApp")]
        [AllowAnonymous]
        [CustomAuthorize("admin, cliente")]
        public async Task<ActionResult<string>> WhatsApp(int id)
        {
            try
            {
                return await _service.WhatsApp(id);
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
