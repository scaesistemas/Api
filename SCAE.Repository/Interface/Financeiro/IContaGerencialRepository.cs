using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Financeiro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Financeiro
{
    public interface IContaGerencialRepository : ICrudRepository<ContaGerencial>
    {
        Task InsertList(List<ContaGerencial> list);
    }
}
