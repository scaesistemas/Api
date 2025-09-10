using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Geral
{
    public class GrauParentescoController : MasterQueryController<GrauParentesco>
    {
        public GrauParentescoController(ILogger<GrauParentescoController> logger, IGrauParentescoService service) : base(logger, service) { }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.AreaCorretor_GrauParentesco_Listar)]
        public override ActionResult<PageResult<GrauParentesco>> Get(ODataQueryOptions<GrauParentesco> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.AreaCorretor_GrauParentesco_Listar)]
        public override Task<ActionResult<GrauParentesco>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
