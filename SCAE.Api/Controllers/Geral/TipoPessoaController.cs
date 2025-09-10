using SCAE.Domain.Entities.Geral;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Geral;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace SCAE.Api.Controllers.Geral
{
    public class TipoPessoaController : MasterQueryController<TipoPessoa>
    {
        public TipoPessoaController(ILogger<TipoPessoaController> logger, ITipoPessoaService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [AllowAnonymous]
        [CheckPermission(Permissoes.Geral_TipoPessoa_Listar)]
        public override ActionResult<PageResult<TipoPessoa>> Get(ODataQueryOptions<TipoPessoa> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [AllowAnonymous]
        [CheckPermission(Permissoes.Geral_TipoPessoa_Listar)]
        public override Task<ActionResult<TipoPessoa>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}