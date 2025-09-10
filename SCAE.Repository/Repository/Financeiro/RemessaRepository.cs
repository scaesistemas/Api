using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class RemessaRepository : CrudRepository<ScaeApiContext, Remessa>, IRemessaRepository
    {
        public RemessaRepository(ScaeApiContext context) : base(context)
        {
        }

        public void ModifiedTransacao(ReceitaTransacao transacao)
        {
            _context.Entry(transacao).State = EntityState.Modified;
        }
    }
}
