using SCAE.Domain.Entities.Financeiro;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using Microsoft.AspNetCore.Authorization;
using SCAE.Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Financeiro
{
    [AllowAnonymous]
    [CustomAuthorize("admin, cliente")]
    public class SituacaoDespesaParcelaController : MasterQueryController<SituacaoDespesaParcela>
    {   
        public SituacaoDespesaParcelaController(ILogger<SituacaoDespesaParcelaController> logger, ISituacaoDespesaParcelaService service) : base(logger, service)
        {

        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_SituacaoDespesaParcela_Listar)]
        public override ActionResult<PageResult<SituacaoDespesaParcela>> Get(ODataQueryOptions<SituacaoDespesaParcela> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_SituacaoDespesaParcela_Listar)]
        public override Task<ActionResult<SituacaoDespesaParcela>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}