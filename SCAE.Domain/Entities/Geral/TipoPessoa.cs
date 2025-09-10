using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("tipopessoa", Schema = "geral")]
    public class TipoPessoa : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoPessoa Fisica => new TipoPessoa(1, "Física");
        [NotMapped] public static TipoPessoa Juridica => new TipoPessoa(2, "Jurídica");

        public TipoPessoa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
