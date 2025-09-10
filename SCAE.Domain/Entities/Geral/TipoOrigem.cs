using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("tipoorigem", Schema = "geral")]
    public class TipoOrigem : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(15), Required] public string Nome { get; set; }

        [NotMapped] public static TipoOrigem Manual => new TipoOrigem(1, "Manual");
        [NotMapped] public static TipoOrigem Requisicao => new TipoOrigem(2, "Requisição");
        [NotMapped] public static TipoOrigem Pedido => new TipoOrigem(3, "Pedido");
        [NotMapped] public static TipoOrigem Inventario => new TipoOrigem(4, "Inventário");

        public TipoOrigem()
        {

        }
        public TipoOrigem(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoOrigem[] ObterDados()
        {
            return new TipoOrigem[]
            {
                Manual,
                Requisicao,
                Pedido,
                Inventario
            };
        }
    }
}
