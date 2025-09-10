using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Projeto;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Projeto;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Projeto
{
    public class OrcadoRepository : CrudRepository<ScaeApiContext, Orcado>, IOrcadoRepository
    {
        public OrcadoRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Empreendimento)
            //    .Include(x => x.Itens)
            //        .ThenInclude(x => x.Etapa)
            //    .Include(x => x.Itens)
            //        .ThenInclude(x => x.Produto);
        }
    }
}
