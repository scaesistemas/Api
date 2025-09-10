using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Geral;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Geral
{
    public interface IEmpresaRepository : ICrudRepository<Empresa>
    {
        Task<EmpresaGateway> GetEmpresaGatewayByIdAsync(int id);
        Task<Empresa> GetByCNPJ(string cnpj);
        void DetachedEmpresaGateway(EmpresaGateway empresa);
        Task RemoveEmpresaGateway(int id);
    }
}
