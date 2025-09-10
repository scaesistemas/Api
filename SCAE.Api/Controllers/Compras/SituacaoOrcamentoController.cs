using SCAE.Domain.Entities.Compras;
using SCAE.Data.Context;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Shared;
using SCAE.Service.Interfaces.Compras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Compras
{
    public class SituacaoOrcamentoController : MasterQueryController<SituacaoOrcamento>
    {
        public SituacaoOrcamentoController(ILogger<SituacaoOrcamentoController> logger, ISituacaoOrcamentoService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Compras_SituacaoOrcamento_Listar)]
        public override ActionResult<PageResult<SituacaoOrcamento>> Get(ODataQueryOptions<SituacaoOrcamento> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Compras_SituacaoOrcamento_Listar)]
        public override Task<ActionResult<SituacaoOrcamento>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}