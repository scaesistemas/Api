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
using Microsoft.AspNetCore.Http;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SCAE.Api.Controllers.Financeiro
{
    public class ContaCorrenteController : MasterCrudController<ContaCorrente>
    {
        private readonly IContaCorrenteService _service;
        public ContaCorrenteController(ILogger<ContaCorrenteController> logger, IContaCorrenteService service) : base(logger, service, "Certificados, Banco")
        {
            _service = service;
        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_ContaCorrente_Cadastrar)]
        public override Task<ActionResult<ContaCorrente>> Post([FromBody] ContaCorrente model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_ContaCorrente_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ContaCorrente> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_ContaCorrente_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] ContaCorrente model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_ContaCorrente_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [AllowAnonymous]
        [CheckPermission(Permissoes.Financeiro_ContaCorrente_Listar)]
        public override ActionResult<PageResult<ContaCorrente>> Get(ODataQueryOptions<ContaCorrente> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [AllowAnonymous]
        [CheckPermission(Permissoes.Financeiro_ContaCorrente_Listar)]
        public override Task<ActionResult<ContaCorrente>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion    
    }
}