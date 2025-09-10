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
    public class ComposicaoController : MasterCrudController<Composicao>
    {
        private readonly IComposicaoService _service;
        public ComposicaoController(ILogger<ComposicaoController> logger, IComposicaoService service) : base(logger, service, "Itens")
        {
            _service = service;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.OrcamentoObras_Composicao_Cadastrar)]
        public override Task<ActionResult<Composicao>> Post([FromBody] Composicao model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_Composicao_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Composicao> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_Composicao_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Composicao model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_Composicao_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.OrcamentoObras_Composicao_Listar)]
        public override ActionResult<PageResult<Composicao>> Get(ODataQueryOptions<Composicao> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.OrcamentoObras_Composicao_Listar)]
        public override Task<ActionResult<Composicao>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }

}