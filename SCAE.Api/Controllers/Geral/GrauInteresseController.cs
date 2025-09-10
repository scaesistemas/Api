using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SCAE.Domain.Entities.Geral.CRMVendas;

namespace SCAE.Api.Controllers.Geral
{
    [AllowAnonymous]
    public class GrauInteresseController : MasterQueryController<GrauInteresse>
    {
        public GrauInteresseController(ILogger<GrauInteresseController> logger, IGrauInteresseService service) : base(logger, service) { }
        
        #region OverrideMasterCRUD-QUERY
        //[CheckPermission(Permissoes.AreaCorretor_GrauInteresse_Listar)]
        public override ActionResult<PageResult<GrauInteresse>> Get(ODataQueryOptions<GrauInteresse> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
       // [CheckPermission(Permissoes.AreaCorretor_GrauInteresse_Listar)]
        public override Task<ActionResult<GrauInteresse>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
