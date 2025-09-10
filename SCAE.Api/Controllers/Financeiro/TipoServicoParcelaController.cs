using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Entities.Financeiro;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Financeiro
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicoParcelaController : MasterCrudController<TipoServicoParcela>
    {
        public TipoServicoParcelaController(ILogger<TipoServicoParcelaController> logger, ITipoServicoParcelaService service) : base(logger, service)
        {

        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_TipoServicoParcela_Cadastrar)]
        public override Task<ActionResult<TipoServicoParcela>> Post([FromBody] TipoServicoParcela model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_TipoServicoParcela_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<TipoServicoParcela> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_TipoServicoParcela_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] TipoServicoParcela model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_TipoServicoParcela_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Financeiro_TipoServicoParcela_Listar)]
        public override ActionResult<PageResult<TipoServicoParcela>> Get(ODataQueryOptions<TipoServicoParcela> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_TipoServicoParcela_Listar)]
        public override Task<ActionResult<TipoServicoParcela>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
