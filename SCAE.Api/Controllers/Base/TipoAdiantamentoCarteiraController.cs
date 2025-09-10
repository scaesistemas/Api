using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using SCAE.Api.Helpers;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Domain.Entities.Base;
using SCAE.Service.Interfaces.Base;

namespace SCAE.Api.Controllers.Base
{
    [AllowAnonymous]
    [CustomAuthorize("admin, cliente")]
    public class TipoAdiantamentoCarteiraController : MasterQueryController<TipoAdiantamentoCarteira>
    {
        public TipoAdiantamentoCarteiraController(ILogger<TipoAdiantamentoCarteiraController> logger, ITipoAdiantamentoCarteiraService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Financeiro_TipoAdiantamentoCarteira_Listar)]
        public override ActionResult<PageResult<TipoAdiantamentoCarteira>> Get(ODataQueryOptions<TipoAdiantamentoCarteira> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_TipoAdiantamentoCarteira_Listar)]
        public override Task<ActionResult<TipoAdiantamentoCarteira>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

    }
}