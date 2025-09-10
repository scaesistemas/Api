using SCAE.Domain.Entities.Financeiro;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Financeiro
{
    public class TipoReceitaController : MasterQueryController<TipoReceita>
    {
        public TipoReceitaController(ILogger<TipoReceitaController> logger, ITipoReceitaService service) : base(logger, service)
        {

        }

        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Financeiro_TipoReceita_Listar)]
        public override ActionResult<PageResult<TipoReceita>> Get(ODataQueryOptions<TipoReceita> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Financeiro_TipoReceita_Listar)]
        public override Task<ActionResult<TipoReceita>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}