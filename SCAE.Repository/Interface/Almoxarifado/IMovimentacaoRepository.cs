using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Almoxarifado;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Almoxarifado
{
    public interface IMovimentacaoRepository : ICrudRepository<Movimentacao>
    {
        Task InsertList(List<Movimentacao> list);
    }
}
