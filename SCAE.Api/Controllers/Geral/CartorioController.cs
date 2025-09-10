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
    public class CartorioController : MasterCrudController<Cartorio>
    {
        public CartorioController(ILogger<CartorioController> logger, ICartorioService service) : base(logger, service)
        {

        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Geral_Cartorio_Cadastrar)]
        public override Task<ActionResult<Cartorio>> Post([FromBody] Cartorio model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Geral_Cartorio_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Cartorio> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Geral_Cartorio_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Cartorio model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Geral_Cartorio_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [CheckPermission(Permissoes.Geral_Cartorio_Listar)]
        public override ActionResult<PageResult<Cartorio>> Get(ODataQueryOptions<Cartorio> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Geral_Cartorio_Listar)]
        public override Task<ActionResult<Cartorio>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}