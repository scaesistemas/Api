using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Interfaces.Geral.CRMVendas;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral.CRMVendas
{
    public class ColunaFunilService : CrudService<ColunaFunil, IColunaFunilRepository>, IColunaFunilService
    {
        private readonly ILeadService _leadService;
        private readonly IUsuarioService _usuarioService;
        public ColunaFunilService(IUsuarioService usuarioService, IColunaFunilRepository repository, ILeadService leadService) : base(repository)
        {
            _leadService = leadService;
            _usuarioService = usuarioService;
        }

    }
}
