using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Financeiro.PlanoDePagamento
{
    [Table("planopagamentomodelo", Schema = "financeiro")]
    public class PlanoPagamentoModelo : PlanoPagamento, IEntity
    {
        public int Id { get; set; }
    }
}
