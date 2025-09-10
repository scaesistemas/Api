using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Geral
{
    public interface IPessoaRepository : ICrudRepository<Pessoa>
    {
        Task<List<Pessoa>> AutoComplete(string q, bool isCliente, bool isFornecedor, bool isCorretor, bool isProprietario,
            bool isSeguradora, bool isAdministradora, bool isConstrutora, bool isTransportadora);
        Task<List<PessoaDocumento>> GetDocumentos(int pessoaId);
        Task<PessoaDocumento> GetDocumentoByIdAsync(int id);
        Task<Pessoa> GetByUserId(int usuarioId);
        Task<Pessoa> GetByCPF(string cpf,string include="");
        Task<PessoaGateway> GetPessoaGatewayByIdAsync(int id);
        Task InsertList(List<Pessoa> list);
        void DetachedPessoaGateway(PessoaGateway pessoa);
        Task RemovePessoaGateway(int id);
    }
}
