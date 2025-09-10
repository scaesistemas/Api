using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("despesabaixacomprovante", Schema = "financeiro")]
    public class DespesaBaixaComprovante : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int DespesaBaixaId { get; set; }
        public DespesaBaixa DespesaBaixa { get; set; }
    }
}
