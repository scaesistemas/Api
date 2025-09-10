using SCAE.Domain.Entities.Geral;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Geral;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;

namespace SCAE.Api.Controllers.Geral
{
    public class SeguradoraController : MasterCrudController<Seguradora>
    {
        public SeguradoraController(ILogger<SeguradoraController> logger, ISeguradoraService service) : base(logger, service)
        {

        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Geral_Seguradora_Cadastrar)]
        public override Task<ActionResult<Seguradora>> Post([FromBody] Seguradora model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Geral_Seguradora_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Seguradora> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Geral_Seguradora_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Seguradora model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Geral_Seguradora_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Geral_Seguradora_Listar)]
        public override ActionResult<PageResult<Seguradora>> Get(ODataQueryOptions<Seguradora> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Geral_Seguradora_Listar)]
        public override Task<ActionResult<Seguradora>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}