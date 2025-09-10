using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Entities.Geral;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Geral;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;

namespace SCAE.Api.Controllers.Geral
{
    public class EmpresaController : MasterCrudController<Empresa>
    {
        private readonly IEmpresaService _service;

        public EmpresaController(ILogger<EmpresaController> logger, IEmpresaService service) : base(logger, service, $"Documentos, ContratoSocialLtda.Usuario, FotoDocumentoResponsavel.Usuario, SelfieResponsavel.Usuario, VersoDocumentoResponsavel.Usuario, Endereco.Estado, Endereco.Municipio")
        {
            _service = service;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Geral_Empresa_Cadastrar)]
        public override Task<ActionResult<Empresa>> Post([FromBody] Empresa model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Geral_Empresa_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Empresa> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Geral_Empresa_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Empresa model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Geral_Empresa_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Geral_Empresa_Listar)]
        public override ActionResult<PageResult<Empresa>> Get(ODataQueryOptions<Empresa> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Geral_Empresa_Listar)]
        public override Task<ActionResult<Empresa>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion
    }
}