using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral
{
    public class TipoPessoaService : QueryService<TipoPessoa, ITipoPessoaRepository>, ITipoPessoaService
    {
        public TipoPessoaService(ITipoPessoaRepository repository) : base(repository)
        {

        }
    }
}
