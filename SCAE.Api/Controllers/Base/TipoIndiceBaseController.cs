using SCAE.Domain.Entities.Financeiro;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using Microsoft.AspNetCore.Authorization;
using SCAE.Service.Interfaces.Base;
using SCAE.Domain.Entities.Base;

namespace SCAE.Api.Controllers.Financeiro
{
    [AllowAnonymous]
    public class TipoIndiceBaseController : MasterQueryController<TipoIndiceBase>
    {
        public TipoIndiceBaseController(ILogger<TipoIndiceBaseController> logger, ITipoIndiceBaseService service) : base(logger, service)
        {

        }

        #region OverrideMasterQUERY
        // [CheckPermission(Permissoes.Financeiro_TipoIndiceBase_Listar)]
        public override ActionResult<PageResult<TipoIndiceBase>> Get(ODataQueryOptions<TipoIndiceBase> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        // [CheckPermission(Permissoes.Financeiro_TipoIndiceBase_Listar)]
        public override Task<ActionResult<TipoIndiceBase>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}