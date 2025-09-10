using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras
{
    [Table("situacaoorcamento", Schema = "compras")]
    public class SituacaoOrcamento : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(45)] [Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoOrcamento EmAnalise => new SituacaoOrcamento(1, "Em Análise");
        [NotMapped] public static SituacaoOrcamento Orcamento => new SituacaoOrcamento(2, "Orçamento");
        [NotMapped] public static SituacaoOrcamento Pedido => new SituacaoOrcamento(3, "Pedido");
        [NotMapped] public static SituacaoOrcamento Concluida => new SituacaoOrcamento(4, "Concluída");
        [NotMapped] public static SituacaoOrcamento Cancelada => new SituacaoOrcamento(5, "Cancelada");

        public SituacaoOrcamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static SituacaoOrcamento[] ObterDados()
        {
            return new SituacaoOrcamento[]
            {
                EmAnalise,
                Orcamento,
                Pedido,
                Concluida,
                Cancelada
            };
        }
    }
}
