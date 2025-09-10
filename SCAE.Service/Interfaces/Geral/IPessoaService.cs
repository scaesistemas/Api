using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Geral
{
    public interface IPessoaService : ICrudService<Pessoa>
    {
        Task<List<Pessoa>> AutoComplete(string q, bool isCliente, bool isFornecedor, bool isCorretor, bool isProprietario,
            bool isSeguradora, bool isAdministradora, bool isConstrutora, bool isTransportadora);
        Task<List<PessoaDocumento>> GetDocumentos(int pessoaId);
        Task RemoverDocumento(int id, int documentoId);
        Task<PessoaDocumento> AdicionarDocumento(int id, PessoaDocumento documento);
        Task<PessoaDocumento> GetDocumentoByIdAsync(int id);
        Task<Pessoa> GetByUserId(int usuarioId);
        Task CriarUsuario(string cpfCnpj);
        Task<Pessoa> GetByCPF(string cpf, string include = "");
        Task ExcluirPessoas();
        Task PostList(List<Pessoa> list, bool saveChanges = true);
    }
}
