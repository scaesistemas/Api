using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Clientes;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Clientes
{
    [AllowAnonymous]
    public class TipoContratoController : MasterCrudController<TipoContrato>
    {
        public TipoContratoController(ILogger<TipoContratoController> logger, ITipoContratoService service) : base(logger, service)
        {

        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Clientes_TipoContrato_Cadastrar)]
        public override Task<ActionResult<TipoContrato>> Post([FromBody] TipoContrato model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Clientes_TipoContrato_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<TipoContrato> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Clientes_TipoContrato_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] TipoContrato model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Clientes_TipoContrato_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Clientes_TipoContrato_Listar)] 
        public override ActionResult<PageResult<TipoContrato>> Get(ODataQueryOptions<TipoContrato> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Clientes_TipoContrato_Listar)]
        public override Task<ActionResult<TipoContrato>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion
    }
}