using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("empresaarquivounico", Schema = "geral")]
    public class EmpresaArquivoUnico : Arquivo, IEntity
    {
        public int Id { get; set; }
    }
}
