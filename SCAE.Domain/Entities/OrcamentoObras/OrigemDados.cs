using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("origemdados", Schema = "orcamentoobras")]
    public class OrigemDados : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static OrigemDados Manual => new(1, "Manual");
        [NotMapped] public static OrigemDados Sinapi => new(2, "Sinapi");

        public OrigemDados(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static OrigemDados[] ObterDados()
        {
            return new OrigemDados[]
            {
                Manual,
                Sinapi
            };
        }
    }
}
