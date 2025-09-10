using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Financeiro;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Financeiro
{
    public class LayoutCobrancaController : MasterQueryController<LayoutCobranca>
    {
        public LayoutCobrancaController(ILogger<LayoutCobrancaController> logger, ILayoutCobrancaService service) : base(logger, service)
        {
        }

        #region OverrideMasterQUERY

        [CheckPermission(Permissoes.Financeiro_LayoutCobranca_Listar)]
        public override ActionResult<PageResult<LayoutCobranca>> Get(ODataQueryOptions<LayoutCobranca> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_LayoutCobranca_Listar)]
        public override Task<ActionResult<LayoutCobranca>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
