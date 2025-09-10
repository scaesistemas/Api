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
    public class SituacaoReservaController : MasterQueryController<SituacaoReserva>
    {
        public SituacaoReservaController(ILogger<SituacaoReservaController> logger, ISituacaoReservaService serive) : base(logger, serive) { }
        #region OverrideMasterCRUD-QUERY
      //  [CheckPermission(Permissoes.AreaCorretor_SituacaoReserva_Listar)]
        public override ActionResult<PageResult<SituacaoReserva>> Get(ODataQueryOptions<SituacaoReserva> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
       // [CheckPermission(Permissoes.AreaCorretor_SituacaoReserva_Listar)]
        public override Task<ActionResult<SituacaoReserva>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
