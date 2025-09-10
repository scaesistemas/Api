using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Financeiro;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Financeiro
{
    [AllowAnonymous]
    public class TipoGatewayController : MasterQueryController<TipoGateway>
    {
        public TipoGatewayController(ILogger<TipoGatewayController> logger, ITipoGatewayService service) : base(logger, service)
        {
        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Financeiro_TipoGateway_Listar)]
        public override ActionResult<PageResult<TipoGateway>> Get(ODataQueryOptions<TipoGateway> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_TipoGateway_Listar)]
        public override Task<ActionResult<TipoGateway>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
