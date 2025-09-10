using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("ExecucaoDocumento", Schema = "projeto")]
    public class ExecucaoDocumento : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int ExecucaoId { get; set; }
        public Execucao Execucao { get; set; }
        public string Descricao { get; set; }
    }
}
