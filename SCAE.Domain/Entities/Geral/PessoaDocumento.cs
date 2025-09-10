using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("pessoadocumento", Schema = "geral")]
    public class PessoaDocumento : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public bool TrocaEndereco { get; set; }

        public PessoaDocumento()
        {

        }

        public PessoaDocumento(int id, int pessoaId, string nome, decimal tamanho, string tipo)
        {
            Id = id;
            PessoaId = pessoaId;
            Nome = nome;
            Tamanho = tamanho;
            Tipo = tipo;
        }
    }
}
