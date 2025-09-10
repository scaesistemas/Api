using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Geral.CRMVendas;
using System.Linq;

namespace SCAE.Data.Interface.Geral.CRMVendas
{
    public interface IAtendimentoRepository : ICrudRepository<Atendimento>
    {
        IQueryable<Atendimento> GetAtendimentoByLeadCorretor(int leadId, int corretorId, string include);
    }
}
