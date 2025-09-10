using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Entities.Financeiro;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Domain.Entities.Geral;
using SCAE.Api.Attributes;

namespace SCAE.Api.Controllers.Financeiro
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagamentoController : MasterCrudController<FormaPagamento>
    {
        public FormaPagamentoController(ILogger<FormaPagamentoController> logger, IFormaPagamentoService service) : base(logger, service)
        {

        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_FormaPagamento_Cadastrar)]
        public override Task<ActionResult<FormaPagamento>> Post([FromBody] FormaPagamento model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_FormaPagamento_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<FormaPagamento> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_FormaPagamento_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] FormaPagamento model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_FormaPagamento_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [CheckPermission(Permissoes.Financeiro_FormaPagamento_Listar)]
        public override ActionResult<PageResult<FormaPagamento>> Get(ODataQueryOptions<FormaPagamento> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_FormaPagamento_Listar)]
        public override Task<ActionResult<FormaPagamento>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion
    }
}