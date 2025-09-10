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

namespace SCAE.Api.Controllers.OrcamentoObras
{
    public class ComposicaoItemController : MasterCrudController<ComposicaoItem>
    {
        public ComposicaoItemController(ILogger<ComposicaoItemController> logger, IComposicaoItemService service) : base(logger, service)
        {
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.OrcamentoObras_ComposicaoItem_Cadastrar)]
        public override Task<ActionResult<ComposicaoItem>> Post([FromBody] ComposicaoItem model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ComposicaoItem_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ComposicaoItem> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ComposicaoItem_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] ComposicaoItem model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ComposicaoItem_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ComposicaoItem_Listar)]
        public override ActionResult<PageResult<ComposicaoItem>> Get(ODataQueryOptions<ComposicaoItem> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ComposicaoItem_Listar)]
        public override Task<ActionResult<ComposicaoItem>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
