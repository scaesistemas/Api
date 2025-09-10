using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Helper;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Framework.Exceptions;
using SCAE.Domain.Models.Financeiro;
using Microsoft.AspNetCore.JsonPatch;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;

namespace SCAE.Api.Controllers.Financeiro
{

    public class ReguaCobrancaController : MasterCrudController<ReguaCobranca>
    { 
        private readonly IReguaCobrancaService _service;

        public ReguaCobrancaController(ILogger<ReguaCobrancaController> logger, IReguaCobrancaService service) : base(logger, service,"Etapas")
        {
            _service = service;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_ReguaCobranca_Cadastrar)]
        public override Task<ActionResult<ReguaCobranca>> Post([FromBody] ReguaCobranca model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_ReguaCobranca_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ReguaCobranca> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_ReguaCobranca_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] ReguaCobranca model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_ReguaCobranca_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }


        [CheckPermission(Permissoes.Financeiro_ReguaCobranca_Listar)]
        public override ActionResult<PageResult<ReguaCobranca>> Get(ODataQueryOptions<ReguaCobranca> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }

        [CheckPermission(Permissoes.Financeiro_ReguaCobranca_Listar)]
        public override Task<ActionResult<ReguaCobranca>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion


        [CheckPermission(Permissoes.Financeiro_ReguaCobranca_Listar)]
        [HttpGet("{id}/Contrato/Page/{page}/Size/{pageSize}")]
        public async Task<ActionResult<ReguaCobrancaModel>> ReguaPrincipal(int id, int page = 1, int pageSize = 10)
        {
            try
            {
                var domain = await _service.GetReguaCobranca(id, page, pageSize);

                return Ok(domain);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }

        [CheckPermission(Permissoes.Financeiro_ReguaCobranca_Listar)]
        [HttpGet("{id}/Contrato")]
        public async Task<ActionResult<ReguaCobrancaModel>> ReguaPrincipalById(int id)
        {
            try
            {
                var domain = await _service.GetReguaCobrancaById(id);

                return Ok(domain);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }

        [CheckPermission(Permissoes.Financeiro_ReguaCobranca_Excluir)]
        [HttpDelete("Etapa/{id}")]
        public async Task<IActionResult> ExcluirEtapa(int id)
        {
            try
            {
                await _service.DeleteEtapa(id);

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }

    }
}
