using SCAE.Domain.Entities.Almoxarifado;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Almoxarifado;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Almoxarifado
{
    public class UnidadeMedidaController : MasterCrudController<UnidadeMedida>
    {
        public UnidadeMedidaController(ILogger<UnidadeMedidaController> logger, IUnidadeMedidaService service) : base(logger, service)
        {
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Almoxarifado_UnidadeMedida_Cadastrar)]
        public override Task<ActionResult<UnidadeMedida>> Post([FromBody] UnidadeMedida model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Almoxarifado_UnidadeMedida_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<UnidadeMedida> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Almoxarifado_UnidadeMedida_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] UnidadeMedida model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Almoxarifado_UnidadeMedida_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Almoxarifado_UnidadeMedida_Listar)]
        public override ActionResult<PageResult<UnidadeMedida>> Get(ODataQueryOptions<UnidadeMedida> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Almoxarifado_UnidadeMedida_Listar)]
        public override Task<ActionResult<UnidadeMedida>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

    }
}