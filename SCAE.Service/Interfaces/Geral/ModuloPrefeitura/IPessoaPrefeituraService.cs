using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using SCAE.Service.Interfaces.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Geral.ModuloPrefeitura
{
    public interface IPessoaPrefeituraService : ICrudService<PessoaPrefeitura>
    {
        Task<List<PessoaPrefeituraDocumento>> GetDocumentos(int pessoaId);
        Task<PessoaPrefeituraDocumento> GetDocumentoByIdAsync(int id);
        Task<PessoaPrefeitura> GetByUserId(int usuarioId);
        Task<PessoaPrefeitura> GetByCPF(string cpf, string include = "");
        Task ExcluirPessoas();
        Task PostList(List<PessoaPrefeitura> list, bool saveChanges = true);
    }
}
