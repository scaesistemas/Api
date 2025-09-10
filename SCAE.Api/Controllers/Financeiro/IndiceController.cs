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
using Microsoft.AspNetCore.Authorization;
using SCAE.Framework.Helper;
using Microsoft.AspNetCore.Http;
using SCAE.Framework.Exceptions;
using System;

namespace SCAE.Api.Controllers.Financeiro
{
    [AllowAnonymous]
    public class IndiceController : MasterCrudController<Indice>
    {
        private readonly IIndiceService _service;
        public IndiceController(ILogger<IndiceController> logger, IIndiceService service) : base(logger, service)
        {
            _service = service;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_Indice_Cadastrar)]
        public override Task<ActionResult<Indice>> Post([FromBody] Indice model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_Indice_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Indice> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_Indice_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Indice model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_Indice_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Financeiro_Indice_Listar)]
        public override ActionResult<PageResult<Indice>> Get(ODataQueryOptions<Indice> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        //payUs
        [CheckPermission(Permissoes.Financeiro_Indice_Listar)]
        public override Task<ActionResult<Indice>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}