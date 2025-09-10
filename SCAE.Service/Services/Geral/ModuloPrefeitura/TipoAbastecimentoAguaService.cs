using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using SCAE.Service.Interfaces.Geral.ModuloPrefeitura;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral.ModuloPrefeitura
{
    public class TipoAbastecimentoAguaService : QueryService<TipoAbastecimentoAgua, ITipoAbastecimentoAguaRepository>, ITipoAbastecimentoAguaService
    {
        public TipoAbastecimentoAguaService(ITipoAbastecimentoAguaRepository repository) : base(repository)
        {

        }
    }
}
