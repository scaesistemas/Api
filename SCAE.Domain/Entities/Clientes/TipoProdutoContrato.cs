using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes
{
    [Table("tipocontratoproduto", Schema = "clientes")]
    public class TipoProdutoContrato : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoProdutoContrato Imovel => new TipoProdutoContrato(1, "Imóvel");
        [NotMapped] public static TipoProdutoContrato Lote => new TipoProdutoContrato(2, "Lote");

        public TipoProdutoContrato(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoProdutoContrato[] ObterDados()
        {
            return new TipoProdutoContrato[]
            {
                Imovel,
                Lote,
            };
        }
    }
}
