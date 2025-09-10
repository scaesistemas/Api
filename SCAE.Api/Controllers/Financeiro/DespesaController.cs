using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Helper;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Framework.Exceptions;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch; 
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Financeiro;
using SCAE.Domain.Entities.Compras;
using SCAE.Api.Models.Financeiro;
using SCAE.Domain.Models.Shared;
using System.Security.Claims;

namespace SCAE.Api.Controllers.Financeiro
{
    [Authorize(Roles = "admin")]
    public class DespesaController : MasterCrudController<Despesa>
    {
        private readonly IDespesaService _service;

        public DespesaController(ILogger<DespesaController> logger, IDespesaService service) : base(logger, service, "Observacoes, Parcelas.Baixas, Classificacoes.CentroCusto, Classificacoes.ContaGerencial , Documentos, Parcelas.ComissaoParcela, Fornecedor")
        {
            _service = service;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_Despesa_Cadastrar)]
        public override Task<ActionResult<Despesa>> Post([FromBody] Despesa model)
        {
            var usuarioId = Convert.ToInt32(User.FindFirst(ClaimTypes.Upn).Value);
            model.UsuarioId = usuarioId;
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Financeiro_Despesa_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Despesa> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_Despesa_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Despesa model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_Despesa_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Financeiro_Despesa_Listar)]
        public override ActionResult<PageResult<Despesa>> Get(ODataQueryOptions<Despesa> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_Despesa_Listar)]
        public override Task<ActionResult<Despesa>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

    }
}