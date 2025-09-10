using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("ExecucaoUnidade", Schema = "projeto")]
    public class ExecucaoUnidade: IEntity
    {
        public int Id { get; set; }
        public int ExecucaoId { get; set; }
        public Execucao Execucao { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade{ get; set; }
    }
}
