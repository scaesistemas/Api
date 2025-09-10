using SCAE.Domain.Interfaces.Shared;

namespace SCAE.Api.Models.Geral
{
    public class ListarPessoaModel : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeCnpjCpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool IsCliente { get; set; }
        public bool IsFornecedor { get; set; }
        public bool IsProprietario { get; set; }
        public bool IsCorretor { get; set; }
        public bool IsSeguradora { get; set; }
    }
}
