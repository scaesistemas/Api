using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using SCAE.Service.Interfaces.Geral.ModuloPrefeitura;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral.ModuloPrefeitura
{
    public class TipoCondicaoMoradiaService : QueryService<TipoCondicaoMoradia, ITipoCondicaoMoradiaRepository>, ITipoCondicaoMoradiaService
    {
        public TipoCondicaoMoradiaService(ITipoCondicaoMoradiaRepository repository) : base(repository)
        {

        }
    }
}
