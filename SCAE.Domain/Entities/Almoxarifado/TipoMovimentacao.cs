using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Almoxarifado
{
    [Table("tipomovimentacao", Schema = "almoxarifado")]
    public class TipoMovimentacao : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoMovimentacao Entrada => new TipoMovimentacao(1, "Entrada");
        [NotMapped] public static TipoMovimentacao Saida => new TipoMovimentacao(2, "Saída");

        public TipoMovimentacao(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
