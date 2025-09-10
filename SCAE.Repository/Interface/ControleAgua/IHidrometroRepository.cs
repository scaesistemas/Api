using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.ControleAgua;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.ControleAgua
{
    public interface IHidrometroRepository : ICrudRepository<Hidrometro>
    {
        void UpdateMarcacao(MarcacaoAgua marcacao);
        Task<MarcacaoAgua> GetMarcacaoByIdTrackingAsync(int id, string include = "");
    }
}
