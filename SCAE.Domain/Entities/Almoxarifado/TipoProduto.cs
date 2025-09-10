using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Almoxarifado
{
    [Table("tipoproduto", Schema = "almoxarifado")]
    public class TipoProduto : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoProduto Produto => new TipoProduto(1, "Produto");
        [NotMapped] public static TipoProduto Servico => new TipoProduto(2, "Serviço");

        public TipoProduto(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
