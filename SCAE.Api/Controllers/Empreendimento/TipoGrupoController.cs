using SCAE.Domain.Entities.Empreendimento;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Empreendimento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Empreendimento
{
    public class TipoGrupoController : MasterQueryController<TipoGrupo>
    {
        public TipoGrupoController(ILogger<TipoGrupoController> logger, ITipoGrupoService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        public override ActionResult<PageResult<TipoGrupo>> Get(ODataQueryOptions<TipoGrupo> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        public override Task<ActionResult<TipoGrupo>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}