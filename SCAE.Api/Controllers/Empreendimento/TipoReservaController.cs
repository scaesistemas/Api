using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Empreendimento;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SCAE.Api.Controllers.Empreendimento
{
    [AllowAnonymous]
    public class TipoReservaController : MasterQueryController<TipoReserva>
    {
        public TipoReservaController(ILogger<TipoReservaController> logger, ITipoReservaService service) : base(logger, service) { }
        #region OverrideMasterCRUD-QUERY
       // [CheckPermission(Permissoes.AreaCorretor_TipoReserva_Listar)]
        public override ActionResult<PageResult<TipoReserva>> Get(ODataQueryOptions<TipoReserva> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
       // [CheckPermission(Permissoes.AreaCorretor_TipoReserva_Listar)]
        public override Task<ActionResult<TipoReserva>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
