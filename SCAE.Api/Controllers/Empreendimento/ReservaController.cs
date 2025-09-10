using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Service.Interfaces.Empreendimento;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SCAE.Api.Controllers.Empreendimento
{
    [AllowAnonymous]
    public class ReservaController : MasterCrudController<Reserva>
    { 
        private readonly IReservaService _service;
        public ReservaController(ILogger<ReservaController> logger, IReservaService service) : base(logger, service, "Observacoes") 
        {
            _service = service;
        }
        #region OverrideMasterCRUD-QUERY
       // [CheckPermission(Permissoes.AreaCorretor_Reserva_Cadastrar)]
        public override Task<ActionResult<Reserva>> Post([FromBody] Reserva model)
        {
            return base.Post(model);
        }
       // [CheckPermission(Permissoes.AreaCorretor_Reserva_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Reserva> model)
        {
            return base.Patch(id, model);
        }
      //  [CheckPermission(Permissoes.AreaCorretor_Reserva_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Reserva model)
        {
            return base.Put(id, model);
        }
      //  [CheckPermission(Permissoes.AreaCorretor_Reserva_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        //@
       // [CheckPermission(Permissoes.AreaCorretor_Reserva_Listar)]
        public override ActionResult<PageResult<Reserva>> Get(ODataQueryOptions<Reserva> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
       // [CheckPermission(Permissoes.AreaCorretor_Reserva_Listar)]
        public override Task<ActionResult<Reserva>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}
