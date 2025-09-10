using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("intervaloreajuste", Schema = "financeiro")]
    public class IntervaloReajuste : IEntity
    {

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(20), Required] public string Nome { get; set; }
        [NotMapped] public static IntervaloReajuste Anual => new IntervaloReajuste(1, "Anual");
        [NotMapped] public static IntervaloReajuste Mensal => new IntervaloReajuste(2, "Mensal");

        public IntervaloReajuste(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static IntervaloReajuste[] ObterDados()
        {
            return new IntervaloReajuste[]
            {
                Anual,
                Mensal
            };
        }

    }
}
