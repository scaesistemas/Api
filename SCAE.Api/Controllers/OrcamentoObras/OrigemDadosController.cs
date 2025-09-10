using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.OrcamentoObras
{
    public class OrigemDadosController : MasterQueryController<OrigemDados>
    {
        public OrigemDadosController(ILogger<OrigemDadosController> logger, IOrigemDadosService service) : base(logger, service)
        {
        }

        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.OrcamentoObras_OrigemDados_Listar)]
        public override ActionResult<PageResult<OrigemDados>> Get(ODataQueryOptions<OrigemDados> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.OrcamentoObras_OrigemDados_Listar)]
        public override Task<ActionResult<OrigemDados>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
