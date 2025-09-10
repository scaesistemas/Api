using SCAE.Domain.Entities.Geral;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Geral;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;

namespace SCAE.Api.Controllers.Geral
{
    public class TipoOrigemController : MasterQueryController<TipoOrigem>
    {
        public TipoOrigemController(ILogger<TipoOrigemController> logger, ITipoOrigemService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Geral_TipoOrigem_Listar)]
        public override ActionResult<PageResult<TipoOrigem>> Get(ODataQueryOptions<TipoOrigem> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Geral_TipoOrigem_Listar)]
        public override Task<ActionResult<TipoOrigem>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

    }
}