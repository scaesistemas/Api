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
    public class InventarioController : MasterCrudController<Inventario>
    {
        public InventarioController(ILogger<InventarioController> logger, IInventarioService service) : base(logger, service, "Itens")
        {
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Almoxarifado_Inventario_Cadastrar)]
        public override Task<ActionResult<Inventario>> Post([FromBody] Inventario model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Almoxarifado_Inventario_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Inventario> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Almoxarifado_Inventario_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Inventario model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Almoxarifado_Inventario_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [CheckPermission(Permissoes.Almoxarifado_Inventario_Listar)]
        public override ActionResult<PageResult<Inventario>> Get(ODataQueryOptions<Inventario> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Almoxarifado_Inventario_Listar)]
        public override Task<ActionResult<Inventario>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}