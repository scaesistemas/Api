using SCAE.Domain.Entities.Geral;
using SCAE.Data.Context;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Shared;
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
    public class NacionalidadeController : MasterQueryController<Nacionalidade>
    {
        public NacionalidadeController(ILogger<NacionalidadeController> logger, INacionalidadeService service) : base(logger, service)
        {

        }

        #region OverrideMasterQUERY

       // [CheckPermission(Permissoes.Geral_Nacionalidade_Listar)]
        public override ActionResult<PageResult<Nacionalidade>> Get(ODataQueryOptions<Nacionalidade> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }

       // [CheckPermission(Permissoes.Geral_Nacionalidade_Listar)]
        public override Task<ActionResult<Nacionalidade>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}