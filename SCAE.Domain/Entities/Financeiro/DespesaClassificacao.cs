using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("despesaclassificacao", Schema = "financeiro")]
    public class DespesaClassificacao : IEntity
    {
        public int Id { get; set; }
        public int DespesaId { get; set; }
        public Despesa Despesa { get; set; }
        public int CentroCustoId { get; set; }
        public CentroCusto CentroCusto { get; set; }
        public int ContaGerencialId { get; set; }
        public ContaGerencial ContaGerencial { get; set; }
        [Required] public decimal Valor { get; set; }
        [Required] public decimal Percentual { get; set; }
    }
}
