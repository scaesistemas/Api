using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;
using SCAE.Service.Interfaces.Financeiro;

namespace SCAE.Api.Controllers.Financeiro
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetornoBancarioController : MasterCrudController<RetornoBancario>
    {
        private readonly IRetornoBancarioService _service;

        public RetornoBancarioController(ILogger<RetornoBancarioController> logger, IRetornoBancarioService service) : base(logger, service)
        {
            _service = service;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_RetornoBancario_Cadastrar)]
        public override Task<ActionResult<RetornoBancario>> Post([FromBody] RetornoBancario model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_RetornoBancario_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<RetornoBancario> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_RetornoBancario_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] RetornoBancario model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_RetornoBancario_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Financeiro_RetornoBancario_Listar)]
        public override ActionResult<PageResult<RetornoBancario>> Get(ODataQueryOptions<RetornoBancario> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_RetornoBancario_Listar)]
        public override Task<ActionResult<RetornoBancario>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
