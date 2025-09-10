using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras
{
    [Table("situacaopedidoitem", Schema = "compras")]
    public class SituacaoPedidoItem : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(45)] [Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoPedidoItem Pendente => new SituacaoPedidoItem(1, "Pendente");
        [NotMapped] public static SituacaoPedidoItem RecebidoParcial => new SituacaoPedidoItem(2, "Recebido Parcial");
        [NotMapped] public static SituacaoPedidoItem RecebidoIntegral => new SituacaoPedidoItem(3, "Recebido Integral");

        public SituacaoPedidoItem(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public static SituacaoPedidoItem[] ObterDados()
        {
            return new SituacaoPedidoItem[]
            {
                Pendente,
                RecebidoParcial,
                RecebidoIntegral
            };
        }
    }
}
