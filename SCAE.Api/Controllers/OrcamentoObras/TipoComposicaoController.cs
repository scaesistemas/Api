using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.OrcamentoObras
{
    public class TipoComposicaoController : MasterCrudController<TipoComposicao>
    {
        public TipoComposicaoController(ILogger<TipoComposicaoController> logger, ITipoComposicaoService service) : base(logger, service)
        {
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.OrcamentoObras_TipoComposicao_Cadastrar)]
        public override Task<ActionResult<TipoComposicao>> Post([FromBody] TipoComposicao model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_TipoComposicao_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<TipoComposicao> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_TipoComposicao_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] TipoComposicao model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_TipoComposicao_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.OrcamentoObras_TipoComposicao_Listar)]
        public override ActionResult<PageResult<TipoComposicao>> Get(ODataQueryOptions<TipoComposicao> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.OrcamentoObras_TipoComposicao_Listar)]
        public override Task<ActionResult<TipoComposicao>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
