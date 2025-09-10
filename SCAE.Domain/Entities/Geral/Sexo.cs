using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("sexo", Schema = "geral")]
    public class Sexo : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static Sexo Masculino => new Sexo(1, "Masculino");
        [NotMapped] public static Sexo Feminino => new Sexo(2, "Feminino");

        public Sexo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static Sexo[] ObterDados()
        {
            return new Sexo[]
            {
                Masculino,
                Feminino
            };
        }
    }
}
