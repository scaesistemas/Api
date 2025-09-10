using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Almoxarifado;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Almoxarifado
{
    public class AlmoxarifadoController : MasterCrudController<Domain.Entities.Almoxarifado.Almoxarifado>
    {
        public AlmoxarifadoController(ILogger<AlmoxarifadoController> logger, IAlmoxarifadoService service) : base(logger, service)
        {
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Almoxarifado_Almoxarifado_Cadastrar)]
        public override Task<ActionResult<Domain.Entities.Almoxarifado.Almoxarifado>> Post([FromBody] Domain.Entities.Almoxarifado.Almoxarifado model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Almoxarifado_Almoxarifado_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Domain.Entities.Almoxarifado.Almoxarifado> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Almoxarifado_Almoxarifado_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Domain.Entities.Almoxarifado.Almoxarifado model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Almoxarifado_Almoxarifado_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Almoxarifado_Almoxarifado_Listar)]
        public override ActionResult<PageResult<Domain.Entities.Almoxarifado.Almoxarifado>> Get(ODataQueryOptions<Domain.Entities.Almoxarifado.Almoxarifado> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Almoxarifado_Almoxarifado_Listar)]
        public override Task<ActionResult<Domain.Entities.Almoxarifado.Almoxarifado>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion

    }
}