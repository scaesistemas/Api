using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Framework.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Financeiro
{
    [Authorize(Roles = "admin")]
    public class ContaGerencialController : MasterCrudController<ContaGerencial>
    {
        private readonly IContaGerencialService _service;

        public ContaGerencialController(ILogger<ContaGerencialController> logger, IContaGerencialService service) : base(logger, service)
        {
            _service = service;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_ContaGerencial_Cadastrar)]
        public override Task<ActionResult<ContaGerencial>> Post([FromBody] ContaGerencial model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_ContaGerencial_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ContaGerencial> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_ContaGerencial_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] ContaGerencial model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_ContaGerencial_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Financeiro_ContaGerencial_Listar)]
        public override ActionResult<PageResult<ContaGerencial>> Get(ODataQueryOptions<ContaGerencial> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_ContaGerencial_Listar)]
        public override Task<ActionResult<ContaGerencial>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}