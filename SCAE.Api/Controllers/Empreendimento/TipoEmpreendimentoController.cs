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
    public class TipoEmpreendimentoController : MasterQueryController<TipoEmpreendimento>
    {
        public TipoEmpreendimentoController(ILogger<TipoEmpreendimentoController> logger, ITipoEmpreendimentoService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Empreendimento_TipoEmpreendimento_Listar)]
        public override ActionResult<PageResult<TipoEmpreendimento>> Get(ODataQueryOptions<TipoEmpreendimento> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Empreendimento_TipoEmpreendimento_Listar)]
        public override Task<ActionResult<TipoEmpreendimento>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}