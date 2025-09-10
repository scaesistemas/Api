using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Entities.Financeiro;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Domain.Entities.Geral;
using Microsoft.AspNetCore.JsonPatch;
using SCAE.Api.Attributes;

using SCAE.Service.Interfaces.Shared;
using Microsoft.Extensions.Options;
using SCAE.Domain.Models.Shared;
using Microsoft.Extensions.Configuration;
using SCAE.Service.Interfaces.Base;


namespace SCAE.Api.Controllers.Financeiro
{
    [Authorize(Roles = "admin")]
    public class ReceitaController : MasterCrudController<Receita>
    {
        private readonly IReceitaService _service;
        // private readonly IGatewayService _gatewayService;
        private readonly IWhatsappService _whatsappService;
        private readonly IEmailService _emailService;
        private readonly IAssinanteService _assinanteService;
        private readonly IConfiguration _configuration;
        private readonly IOptions<BaseSettingModel> _baseSetting;

        public ReceitaController(ILogger<ReceitaController> logger, IReceitaService service, IWhatsappService whatsappService, IEmailService emailService, IAssinanteService assinanteService, IConfiguration configuration, IOptions<BaseSettingModel> baseSetting) : base(logger, service, "Parcelas.Baixas, Classificacoes, Documentos")
        {
            _service = service;
            // _gatewayService = gatewayService;
            _whatsappService = whatsappService;
            _emailService = emailService;
            _assinanteService = assinanteService;
            _configuration = configuration;
            _baseSetting = baseSetting;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Financeiro_Receita_Cadastrar)]
        public override Task<ActionResult<Receita>> Post([FromBody] Receita model)
        {
            return base.Post(model);

        }
        [CheckPermission(Permissoes.Financeiro_Receita_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Receita> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_Receita_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Receita model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Financeiro_Receita_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.Financeiro_Receita_Listar)]
        public override ActionResult<PageResult<Receita>> Get(ODataQueryOptions<Receita> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        //RAM
        [CheckPermission(Permissoes.Financeiro_Receita_Listar)]
        public override Task<ActionResult<Receita>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

       
    }
}




