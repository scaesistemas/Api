using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Helper;
using System.Collections.Generic;
using System;

namespace SCAE.Api.Controllers.OrcamentoObras
{
    public class OrcamentoEtapaController : MasterCrudController<OrcamentoEtapa>
    {
        IOrcamentoEtapaService _service;
        public OrcamentoEtapaController(ILogger<OrcamentoEtapaController> logger, IOrcamentoEtapaService service) : base(logger, service, "Itens, Orcamento")
        {
            _service = service;
        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Cadastrar)]
        public override Task<ActionResult<OrcamentoEtapa>> Post([FromBody] OrcamentoEtapa model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<OrcamentoEtapa> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] OrcamentoEtapa model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Listar)]
        public override ActionResult<PageResult<OrcamentoEtapa>> Get(ODataQueryOptions<OrcamentoEtapa> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Listar)]
        public override Task<ActionResult<OrcamentoEtapa>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

        [HttpGet("TreeView")]
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Listar)]
        public async Task<ActionResult<List<OrcamentoEtapa>>> ListagemTreeView(int orcamentoId)
        {
            try
            {
                var lista = await _service.TreeView(orcamentoId);

                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }
    }
}
