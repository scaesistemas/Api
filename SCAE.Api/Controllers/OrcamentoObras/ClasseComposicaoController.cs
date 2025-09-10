using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.OrcamentoObras
{
    public class ClasseComposicaoController : MasterCrudController<ClasseComposicao>
    {
        public ClasseComposicaoController(ILogger<ClasseComposicaoController> logger, IClasseComposicaoService service) : base(logger, service)
        {
        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Cadastrar)]
        public override Task<ActionResult<ClasseComposicao>> Post([FromBody] ClasseComposicao model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ClasseComposicao> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] ClasseComposicao model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Listar)]
        public override ActionResult<PageResult<ClasseComposicao>> Get(ODataQueryOptions<ClasseComposicao> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Listar)]
        public override Task<ActionResult<ClasseComposicao>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
