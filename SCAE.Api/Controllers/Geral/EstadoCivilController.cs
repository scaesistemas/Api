using SCAE.Domain.Entities.Geral;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Geral;
using SCAE.Api.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SCAE.Api.Controllers.Geral
{
    [AllowAnonymous]
    public class EstadoCivilController : MasterQueryController<EstadoCivil>
    {
        public EstadoCivilController(ILogger<EstadoCivilController> logger, IEstadoCivilService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Geral_EstadoCivil_Listar)]
        public override ActionResult<PageResult<EstadoCivil>> Get(ODataQueryOptions<EstadoCivil> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Geral_EstadoCivil_Listar)]
        public override Task<ActionResult<EstadoCivil>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion
    }
}