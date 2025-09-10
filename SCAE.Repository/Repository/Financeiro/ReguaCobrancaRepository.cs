using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Interface.Projeto;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Financeiro
{
    public class ReguaCobrancaRepository : CrudRepository<ScaeApiContext, ReguaCobranca>, IReguaCobrancaRepository
    {
        public ReguaCobrancaRepository(ScaeApiContext context) : base(context)
        {



        }

        public async Task<ReguaCobrancaEtapa> GetEtapaByIdAsync(int id)
        {
            return await _context.Set<ReguaCobrancaEtapa>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
        public async Task ExcluirEtapa(int EtapaId)
        {
            var entity = await GetEtapaByIdAsync(EtapaId);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }
    }
}
