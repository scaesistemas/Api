using SCAE.Domain.Entities.Financeiro;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

namespace SCAE.Api.Controllers.Financeiro
{
    [AllowAnonymous]
    public class TipoIndiceController : MasterCrudController<TipoIndice>
    {
        public TipoIndiceController(ILogger<TipoIndiceController> logger, ITipoIndiceService service) : base(logger, service)
        {

        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_TipoIndice_Cadastrar)]
        public override Task<ActionResult<TipoIndice>> Post([FromBody] TipoIndice model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_TipoIndice_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<TipoIndice> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_TipoIndice_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] TipoIndice model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_TipoIndice_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Financeiro_TipoIndice_Listar)]
        public override ActionResult<PageResult<TipoIndice>> Get(ODataQueryOptions<TipoIndice> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_TipoIndice_Listar)]
        public override Task<ActionResult<TipoIndice>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
        

    }
}