using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Messenger
{
    public interface ITelegramService
    {
        int AssinanteIdToTopicoId(int assinanteId);
        Task Enviar(int topicoId, string texto, ILogger logger);
    }
}
