using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras
{
    [Table("situacaopedido", Schema = "compras")]
    public class SituacaoPedido : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(45)] [Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoPedido EmAnalise => new SituacaoPedido(1, "Em Análise");
        [NotMapped] public static SituacaoPedido Orcamento => new SituacaoPedido(2, "Orçamento");
        [NotMapped] public static SituacaoPedido Pedido => new SituacaoPedido(3, "Pedido");
        [NotMapped] public static SituacaoPedido Concluida => new SituacaoPedido(4, "Concluída");
        [NotMapped] public static SituacaoPedido Cancelada => new SituacaoPedido(5, "Cancelada");

        public SituacaoPedido(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static SituacaoPedido[] ObterDados()
        {
            return new SituacaoPedido[]
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
