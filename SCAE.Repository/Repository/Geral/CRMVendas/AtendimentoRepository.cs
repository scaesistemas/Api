using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Domain.Models.Geral.CRMVendas;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Geral.CRMVendas
{
    public class AtendimentoRepository : CrudRepository<ScaeApiContext, Atendimento>, IAtendimentoRepository
    {
        public AtendimentoRepository(ScaeApiContext context) : base(context)
        {

        }

        public IQueryable<Atendimento> GetAtendimentoByLeadCorretor(int leadId, int corretorId, string include)
        {
            if(corretorId <= 0)
            {
                return GetAll(include).Where(x => x.LeadId == leadId).AsNoTracking();
            }
            else
            {
                return GetAll(include).Where(x => x.LeadId == leadId && x.CorretorId == corretorId).AsNoTracking();
            }
        }
    }
}
