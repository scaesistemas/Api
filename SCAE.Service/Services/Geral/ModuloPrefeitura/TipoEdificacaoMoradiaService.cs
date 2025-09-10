using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using SCAE.Service.Interfaces.Geral.ModuloPrefeitura;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral.ModuloPrefeitura
{
    public class TipoEdificacaoMoradiaService : QueryService<TipoEdificacaoMoradia, ITipoEdificacaoMoradiaRepository>, ITipoEdificacaoMoradiaService
    {
        public TipoEdificacaoMoradiaService(ITipoEdificacaoMoradiaRepository repository) : base(repository)
        {
        }
    }
}
