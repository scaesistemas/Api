using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using SCAE.Service.Interfaces.Geral.ModuloPrefeitura;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral.ModuloPrefeitura
{
    public class TipoEsgotamentoSanitarioService : QueryService<TipoEsgotamentoSanitario, ITipoEsgotamentoSanitarioRepository>, ITipoEsgotamentoSanitarioService
    {
        public TipoEsgotamentoSanitarioService(ITipoEsgotamentoSanitarioRepository repository) : base(repository)
        {
        }
    }
}
