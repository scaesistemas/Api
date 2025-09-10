using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Interface.Financeiro
{
    public interface IRemessaRepository :ICrudRepository<Remessa>
    {

        void ModifiedTransacao(ReceitaTransacao transacao);
    }
}
