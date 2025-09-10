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
    public class SituacaoAdiantamentoCarteiraController : MasterQueryController<SituacaoAdiantamentoCarteira>
    {
        public SituacaoAdiantamentoCarteiraController(ILogger<SituacaoAdiantamentoCarteiraController> logger, ISituacaoAdiantamentoCarteiraService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Financeiro_SituacaoAdiantamentoCarteira_Listar)]
        public override ActionResult<PageResult<SituacaoAdiantamentoCarteira>> Get(ODataQueryOptions<SituacaoAdiantamentoCarteira> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_SituacaoAdiantamentoCarteira_Listar)]
        public override Task<ActionResult<SituacaoAdiantamentoCarteira>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

    }
}