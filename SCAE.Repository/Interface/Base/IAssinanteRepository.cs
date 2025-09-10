using System.Collections.Generic;
using System.Threading.Tasks;
using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Base;

namespace SCAE.Data.Interface.Base
{
    public interface IAssinanteRepository : ICrudRepository<Assinante>
    {
        Assinante ObterAssinante(string host);
        void DetachedDominio(AssinanteDominio parcela);
        Task<AssinanteDominio> GetDominioByIdAsync(int id);
        Task RemoveDominio(int id);
    }
}
