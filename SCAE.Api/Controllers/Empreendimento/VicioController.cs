using SCAE.Domain.Entities.Empreendimento;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Empreendimento;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Empreendimento
{
    public class VicioController : MasterCrudController<Vicio>
    {
        public VicioController(ILogger<VicioController> logger, IVicioService service) : base(logger, service)
        {

        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Empreendimento_Vicio_Cadastrar)]
        public override Task<ActionResult<Vicio>> Post([FromBody] Vicio model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Empreendimento_Vicio_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Vicio> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Empreendimento_Vicio_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Vicio model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Empreendimento_Vicio_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [CheckPermission(Permissoes.Empreendimento_Vicio_Listar)]
        public override ActionResult<PageResult<Vicio>> Get(ODataQueryOptions<Vicio> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Empreendimento_Vicio_Listar)]
        public override Task<ActionResult<Vicio>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion
    }
}