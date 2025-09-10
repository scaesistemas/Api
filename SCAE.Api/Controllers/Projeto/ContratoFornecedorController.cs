using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Projeto;
using SCAE.Service.Interfaces.Projeto;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Projeto
{
    public class ContratoFornecedorController : MasterCrudController<ContratoFornecedor>
    {
        public ContratoFornecedorController(ILogger<ContratoFornecedorController> logger, IContratoFornecedorService service) : base(logger, service, "Observacoes, Itens, Documentos, Tipo")
        {
            
        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Projeto_ContratoFornecedor_Cadastrar)]
        public override Task<ActionResult<ContratoFornecedor>> Post([FromBody] ContratoFornecedor model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Projeto_ContratoFornecedor_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ContratoFornecedor> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Projeto_ContratoFornecedor_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] ContratoFornecedor model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Projeto_ContratoFornecedor_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Projeto_ContratoFornecedor_Listar)]
        public override ActionResult<PageResult<ContratoFornecedor>> Get(ODataQueryOptions<ContratoFornecedor> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Projeto_ContratoFornecedor_Listar)]
        public override Task<ActionResult<ContratoFornecedor>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
