using SCAE.Domain.Entities.Clientes;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Clientes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SCAE.Domain.Entities.Geral;
using SCAE.Api.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;

namespace SCAE.Api.Controllers.Clientes
{

    public class ContratoController : MasterCrudController<Contrato>
    {
        public ContratoController(ILogger<ContratoController> logger, IContratoService service) :
            base(logger, service, "Receitas.Parcelas, Despesas.Parcelas,Despesas.Fornecedor, Vistorias, Documentos, Observacoes, Clientes, Corretores, ContratosDigitais.Documento")
        {
        }

        [CheckPermission(Permissoes.Clientes_Contrato_Cadastrar)]
        public override Task<ActionResult<Contrato>> Post([FromBody] Contrato model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Clientes_Contrato_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Contrato> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Clientes_Contrato_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Contrato model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Clientes_Contrato_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [CheckPermission(Permissoes.Clientes_Contrato_Listar)]
        public override ActionResult<PageResult<Contrato>> Get(ODataQueryOptions<Contrato> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }


    }
}
