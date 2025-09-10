using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Interfaces.Geral.CRMVendas;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral.CRMVendas
{
    public class LeadService : CrudService<Lead, ILeadRepository>, ILeadService
    {
        private readonly IUsuarioService _usuarioService;
        public LeadService(IUsuarioService usuarioService, ILeadRepository repository) : base(repository)
        {
            _usuarioService = usuarioService;
        }
    }
}
