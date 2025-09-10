using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("receitaclassificacao", Schema = "financeiro")]
    public class ReceitaClassificacao
    {
        public int Id { get; set; }
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }
        public int CentroCustoId { get; set; }
        public CentroCusto CentroCusto { get; set; }
        public int ContaGerencialId { get; set; }
        public ContaGerencial ContaGerencial { get; set; }
        [Required] public decimal Valor { get; set; }
        [Required] public decimal Percentual { get; set; }
    }
}
