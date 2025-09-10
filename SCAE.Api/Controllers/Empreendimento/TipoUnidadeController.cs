using SCAE.Domain.Entities.Empreendimento;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Empreendimento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Empreendimento
{
    public class TipoUnidadeController : MasterQueryController<TipoUnidade>
    {
        public TipoUnidadeController(ILogger<TipoUnidadeController> logger, ITipoUnidadeService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Empreendimento_TipoUnidade_Listar)]
        public override ActionResult<PageResult<TipoUnidade>> Get(ODataQueryOptions<TipoUnidade> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Empreendimento_TipoUnidade_Listar)]
        public override Task<ActionResult<TipoUnidade>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}