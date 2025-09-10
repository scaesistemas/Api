using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Financeiro;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Financeiro
{
    public interface IReguaCobrancaRepository : ICrudRepository<ReguaCobranca>
    {
        Task<ReguaCobrancaEtapa> GetEtapaByIdAsync(int id);
        Task ExcluirEtapa(int EtapaId);
    }
}
