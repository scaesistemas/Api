using SCAE.Domain.Entities.Financeiro;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Http;
using SCAE.Framework.Helper;

namespace SCAE.Api.Controllers.Financeiro
{
    public class BancoController : MasterCrudController<Banco>
    {
        public BancoController(ILogger<BancoController> logger, IBancoService service) : base(logger, service)
        {

        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_Banco_Cadastrar)]
        public override Task<ActionResult<Banco>> Post([FromBody] Banco model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_Banco_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Banco> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_Banco_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Banco model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_Banco_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Financeiro_Banco_Listar)]
        public override ActionResult<PageResult<Banco>> Get(ODataQueryOptions<Banco> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_Banco_Listar)]
        public override Task<ActionResult<Banco>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion


    }
}