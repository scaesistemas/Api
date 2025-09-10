using SCAE.Domain.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Development
{
    public interface IApiDevelopmentService
    {
        Task<string> AutenticarUsuario();
        Task<List<Assinante>> GetAssinante();
        Task<Assinante> GetAssinanteById(int id);
    }
}
