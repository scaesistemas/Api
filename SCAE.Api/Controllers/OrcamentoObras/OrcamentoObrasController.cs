using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.OrcamentoObras;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.OrcamentoObras
{
    public class OrcamentoObrasController : MasterCrudController<Domain.Entities.OrcamentoObras.OrcamentoObras>
    {
        public OrcamentoObrasController(ILogger<OrcamentoObrasController> logger, IOrcamentoObrasService service) : base(logger, service, "Etapas.Itens")
        {
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoObras_Cadastrar)]
        public override Task<ActionResult<Domain.Entities.OrcamentoObras.OrcamentoObras>> Post([FromBody] Domain.Entities.OrcamentoObras.OrcamentoObras model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoObras_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Domain.Entities.OrcamentoObras.OrcamentoObras> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoObras_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Domain.Entities.OrcamentoObras.OrcamentoObras model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoObras_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoObras_Listar)]
        public override ActionResult<PageResult<Domain.Entities.OrcamentoObras.OrcamentoObras>> Get(ODataQueryOptions<Domain.Entities.OrcamentoObras.OrcamentoObras> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoObras_Listar)]
        public override Task<ActionResult<Domain.Entities.OrcamentoObras.OrcamentoObras>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
