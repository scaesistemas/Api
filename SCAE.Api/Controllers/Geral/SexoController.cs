using SCAE.Domain.Entities.Geral;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Geral;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace SCAE.Api.Controllers.Geral
{
    [AllowAnonymous]
    public class SexoController : MasterQueryController<Sexo>
    {
        public SexoController(ILogger<SexoController> logger, ISexoService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
      //  [CheckPermission(Permissoes.Geral_Sexo_Listar)]
        public override ActionResult<PageResult<Sexo>> Get(ODataQueryOptions<Sexo> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
       // [CheckPermission(Permissoes.Geral_Sexo_Listar)]
        public override Task<ActionResult<Sexo>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}