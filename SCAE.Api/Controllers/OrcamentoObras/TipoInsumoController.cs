using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.OrcamentoObras
{
    public class TipoInsumoController : MasterQueryController<TipoInsumo>
    {
        public TipoInsumoController(ILogger<TipoInsumoController> logger, ITipoInsumoService service) : base(logger, service)
        {
        }

        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.OrcamentoObras_TipoInsumo_Listar)]
        public override ActionResult<PageResult<TipoInsumo>> Get(ODataQueryOptions<TipoInsumo> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.OrcamentoObras_TipoInsumo_Listar)]
        public override Task<ActionResult<TipoInsumo>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
