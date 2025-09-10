using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Geral
{
    public class TipoProcessoJudicialController : MasterCrudController<TipoProcessoJudicial>
    {
        public TipoProcessoJudicialController(ILogger<TipoProcessoJudicialController> logger, ITipoProcessoJudicialService service, string includePatch = "") : base(logger, service, includePatch)
        {
        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Geral_TipoProcessoJudicial_Cadastrar)]
        public override Task<ActionResult<TipoProcessoJudicial>> Post([FromBody] TipoProcessoJudicial model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Geral_TipoProcessoJudicial_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<TipoProcessoJudicial> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Geral_TipoProcessoJudicial_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] TipoProcessoJudicial model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Geral_TipoProcessoJudicial_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Geral_TipoProcessoJudicial_Listar)]
        public override ActionResult<PageResult<TipoProcessoJudicial>> Get(ODataQueryOptions<TipoProcessoJudicial> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Geral_TipoProcessoJudicial_Listar)]
        public override Task<ActionResult<TipoProcessoJudicial>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
