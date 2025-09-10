using SCAE.Domain.Entities.Empreendimento;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Empreendimento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Clientes
{
    public class TipoImovelController : MasterQueryController<TipoImovel>
    {
        public TipoImovelController(ILogger<TipoImovelController> logger, ITipoImovelService service) : base(logger, service)
        {

        }

        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Empreendimento_TipoImovel_Listar)]
        public override ActionResult<PageResult<TipoImovel>> Get(ODataQueryOptions<TipoImovel> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Empreendimento_TipoImovel_Listar)]
        public override Task<ActionResult<TipoImovel>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}