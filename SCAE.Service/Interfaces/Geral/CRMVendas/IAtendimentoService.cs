using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Domain.Models.Geral.CRMVendas;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Geral.CRMVendas
{
    public interface IAtendimentoService : ICrudService<Atendimento>
    {
        Task<AtendimentoTarefaModel> GetAtendimentoByLeadCorretor(int leadId, int corretorId, string include);
        Task AlterarRealizado(int atendimentoId, bool realizado);
    }
}
