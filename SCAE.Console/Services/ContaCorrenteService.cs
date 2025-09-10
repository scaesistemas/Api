using SCAE.Migracao.Data;
using SCAE.Migracao.Entities;
using System.Linq;

namespace SCAE.Migracao.Services
{
    public class ContaCorrenteService
    {
        public ContaCorrente ObterById(int id)
        {
            using var context = new MigracaoContext();

            return context.ContaCorrentes.SingleOrDefault(x => x.Id == id);
        }
    }
}
