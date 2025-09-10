using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Geral.ModuloPrefeitura
{
    public interface IPessoaPrefeituraRepository : ICrudRepository<PessoaPrefeitura>
    {
        Task<List<PessoaPrefeituraDocumento>> GetDocumentos(int pessoaId);
        Task<PessoaPrefeituraDocumento> GetDocumentoByIdAsync(int id);
        Task<PessoaPrefeitura> GetByUserId(int usuarioId);
        Task<PessoaPrefeitura> GetByCPF(string cpf, string include = "");
        Task InsertList(List<PessoaPrefeitura> list);
    }
}
