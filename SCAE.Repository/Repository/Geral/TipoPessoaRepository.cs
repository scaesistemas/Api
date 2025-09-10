using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class TipoPessoaRepository : QueryRepository<ScaeApiContext, TipoPessoa>, ITipoPessoaRepository
    {
        public TipoPessoaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
