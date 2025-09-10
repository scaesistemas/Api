using SCAE.Domain.Entities.Financeiro;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using Microsoft.AspNetCore.Authorization;
using SCAE.Api.Helpers;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Financeiro
{
    [AllowAnonymous]
    [CustomAuthorize("admin, cliente")]
    public class SituacaoReceitaParcelaController : MasterQueryController<SituacaoReceitaParcela>
    {
        public SituacaoReceitaParcelaController(ILogger<SituacaoReceitaParcelaController> logger, ISituacaoReceitaParcelaService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Financeiro_SituacaoReceitaParcela_Listar)]
        public override ActionResult<PageResult<SituacaoReceitaParcela>> Get(ODataQueryOptions<SituacaoReceitaParcela> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_SituacaoReceitaParcela_Listar)]
        public override Task<ActionResult<SituacaoReceitaParcela>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

    }
}