using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Geral
{
    [Table("estadocivil", Schema = "geral")]
    public class EstadoCivil : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static EstadoCivil Solteiro => new(1, "Solteiro(a)");
        [NotMapped] public static EstadoCivil Casado => new(2, "Casado(a)");
        [NotMapped] public static EstadoCivil Viuvo => new(3, "Viúvo(a)");
        [NotMapped] public static EstadoCivil Divorciado => new(4, "Divorciado(a)");
        [NotMapped] public static EstadoCivil Separado => new(5, "Separado(a) Judicialmente");
        [NotMapped] public static EstadoCivil UniaoEstavel => new(6, "União Estável");

        public EstadoCivil(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static EstadoCivil[] ObterDados()
        {
            return new EstadoCivil[]
            {
                Solteiro,
                Casado,
                Viuvo,
                Divorciado,
                Separado,
                UniaoEstavel
            };
        }

        public static EstadoCivil ObterPorNome(string estadoCivil)
        {
            if (string.IsNullOrEmpty(estadoCivil))
                return null;

            return ObterDados()
                    .SingleOrDefault(x => x.Nome.ToUpper() == estadoCivil.ToUpper() || 
                    x.Nome.Replace("o(a)", "a").ToUpper() == estadoCivil.ToUpper() || 
                    x.Nome.Replace("(a)", "").ToUpper()== estadoCivil.ToUpper());
        }
    }
}
