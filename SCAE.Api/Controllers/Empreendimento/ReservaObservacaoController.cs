using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Empreendimento;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SCAE.Api.Controllers.Empreendimento
{
    [AllowAnonymous]
    public class ReservaObservacaoController : MasterCrudController<ReservaObservacao>
    {
        public ReservaObservacaoController(ILogger<ReservaObservacaoController> logger, IReservaObservacaoService service) : base(logger, service) { }
        #region OverrideMasterCRUD-QUERY
       // [CheckPermission(Permissoes.AreaCorretor_ReservaObservacao_Cadastrar)]
        public override Task<ActionResult<ReservaObservacao>> Post([FromBody] ReservaObservacao model)
        {
            return base.Post(model);
        }
       // [CheckPermission(Permissoes.AreaCorretor_ReservaObservacao_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ReservaObservacao> model)
        {
            return base.Patch(id, model);
        }
       // [CheckPermission(Permissoes.AreaCorretor_ReservaObservacao_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] ReservaObservacao model)
        {
            return base.Put(id, model);
        }
       // [CheckPermission(Permissoes.AreaCorretor_ReservaObservacao_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

       // [CheckPermission(Permissoes.AreaCorretor_ReservaObservacao_Listar)]
        public override ActionResult<PageResult<ReservaObservacao>> Get(ODataQueryOptions<ReservaObservacao> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
       // [CheckPermission(Permissoes.AreaCorretor_ReservaObservacao_Listar)]
        public override Task<ActionResult<ReservaObservacao>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
