using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Geral
{
    [AllowAnonymous]
    public class TipoEscolaridadeController : MasterQueryController<TipoEscolaridade>
    {
        public TipoEscolaridadeController(ILogger<TipoEscolaridadeController> logger, ITipoEscolaridadeService service) : base(logger, service)
        {
        }
        #region OverrideMasterQUERY
        
        public override ActionResult<PageResult<TipoEscolaridade>> Get(ODataQueryOptions<TipoEscolaridade> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        
        public override Task<ActionResult<TipoEscolaridade>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
