using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
    public class CentroCustoController : MasterCrudController<CentroCusto>
    {
        private readonly ICentroCustoService _service;

        public CentroCustoController(ILogger<CentroCustoController> logger, ICentroCustoService service) : base(logger, service)
        {
            _service = service;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_CentroCusto_Cadastrar)]
        public override Task<ActionResult<CentroCusto>> Post([FromBody] CentroCusto model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_CentroCusto_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<CentroCusto> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_CentroCusto_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] CentroCusto model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_CentroCusto_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Financeiro_CentroCusto_Listar)]
        public override ActionResult<PageResult<CentroCusto>> Get(ODataQueryOptions<CentroCusto> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_CentroCusto_Listar)]
        public override Task<ActionResult<CentroCusto>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion

    }
}