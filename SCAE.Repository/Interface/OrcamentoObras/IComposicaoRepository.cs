using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.OrcamentoObras;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.OrcamentoObras
{
    public interface IComposicaoRepository : ICrudRepository<Composicao>
    {
        Task InsertList(List<Composicao> list);
    }
}
