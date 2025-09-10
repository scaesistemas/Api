using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Financeiro;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Financeiro
{
    public interface IParametroRepository : ICrudRepository<Parametro>
    {
        Task<Parametro> GetFirst(int empresaId);
        Task<ParametroCobranca> GetCobrancaById(int cobrancaId);
        Task<ParametroGatway> GetGatewayById(int gatewayId);
        IQueryable<ParametroGatway> GetGatewayAll();
        IQueryable<Parametro> GetAllByEmpresaId(int empresaId);
    }
}
 