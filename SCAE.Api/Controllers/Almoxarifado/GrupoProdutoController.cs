using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Almoxarifado;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Almoxarifado
{
    public class GrupoProdutoController : MasterCrudController<GrupoProduto>
    {
        public GrupoProdutoController(ILogger<GrupoProdutoController> logger, IGrupoProdutoService service) : base(logger, service)
        {
        }

        #region OverrideMasterCRUD-QUERY

        [CheckPermission(Permissoes.Almoxarifado_GrupoProduto_Cadastrar)]
        public override Task<ActionResult<GrupoProduto>> Post([FromBody] GrupoProduto model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Almoxarifado_GrupoProduto_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<GrupoProduto> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Almoxarifado_GrupoProduto_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] GrupoProduto model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Almoxarifado_GrupoProduto_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Almoxarifado_GrupoProduto_Listar)]
        public override ActionResult<PageResult<GrupoProduto>> Get(ODataQueryOptions<GrupoProduto> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Almoxarifado_GrupoProduto_Listar)]
        public override Task<ActionResult<GrupoProduto>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}