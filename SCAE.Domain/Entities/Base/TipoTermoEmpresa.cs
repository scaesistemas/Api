using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Base
{
    [Table("tipotermoempresa", Schema = "base")]
    public class TipoTermoEmpresa : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoTermoEmpresa Scae => new TipoTermoEmpresa(1, "Scae");
        [NotMapped] public static TipoTermoEmpresa Celcoin => new TipoTermoEmpresa(2, "Celcoin");

        public TipoTermoEmpresa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoTermoEmpresa[] ObterDados()
        {
            return new TipoTermoEmpresa[]
            {
                Scae,
                Celcoin
            };
        }
    }
}
