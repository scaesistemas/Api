using System.ComponentModel.DataAnnotations.Schema;
using SCAE.Domain.Interfaces.Shared;

namespace SCAE.Domain.Entities.Geral
{
    [Table("pessoaarquivounico", Schema = "geral")]
    public class PessoaArquivoUnico : Arquivo, IEntity
    {
        public int Id { get; set; }
    }
}