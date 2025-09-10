using Microsoft.AspNetCore.Authorization;
using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral
{
    public class TipoEmpresaService : QueryService<TipoEmpresa, ITipoEmpresaRepository>, ITipoEmpresaService
    {
        public TipoEmpresaService(ITipoEmpresaRepository repository) : base(repository)
        {

        }
    }
}
