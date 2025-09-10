using SCAE.Data.Context;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Projeto;
using SCAE.Data.Interface.Projeto;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SCAE.Data.Repository.Projeto
{
    public class ContratoFornecedorRepository:CrudRepository<ScaeApiContext, ContratoFornecedor>, IContratoFornecedorRepository
    {
        public ContratoFornecedorRepository(ScaeApiContext context) : base(context)
        {
            
        }

        public int ProximoNumero()
        {
            return _context.ContratoFornecedor.AsNoTracking()
                .OrderByDescending(x => x.Numero).Take(1)
                .SingleOrDefault()?.Numero + 1 ?? 1;
        }
    }
}
