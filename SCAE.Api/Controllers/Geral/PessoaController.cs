using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Entities.Geral;
using SCAE.Framework.Helper;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Geral;
using SCAE.Api.Helpers;
using SCAE.Framework.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;
using SCAE.Api.Models.Geral;
using SCAE.Data.Interface.Geral;
using System.Linq;
using SCAE.Service.Interfaces.Geral.CRMVendas;
using SCAE.Domain.Entities.Geral.CRMVendas;

namespace SCAE.Api.Controllers.Geral
{
    [Authorize(Roles = "admin")]
    public class PessoaController : MasterCrudController<Pessoa>
    {
        public PessoaController(ILogger<MasterCrudController<Pessoa>> logger, IPessoaService service, string includePatch = "Documentos,Familiares,Contatos, EmpreendimentosPessoas") : base(logger, service, includePatch)
        {
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Geral_Pessoa_Cadastrar)]
        public override Task<ActionResult<Pessoa>> Post([FromBody] Pessoa model)
        {
            return base.Post(model);
        }

        [CheckPermission(Permissoes.Geral_Pessoa_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Pessoa model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Geral_Pessoa_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [AllowAnonymous]
        [CheckPermission(Permissoes.Geral_Pessoa_Listar)]
        public override ActionResult<PageResult<Pessoa>> Get(ODataQueryOptions<Pessoa> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        #endregion

        //public PessoaController(ILogger<PessoaController> logger, IPessoaService service, IUsuarioService usuarioService) : base(logger, service)
        //{
        //    _service = service;
        //    _usuarioService = usuarioService;
        //}
    }
}