using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("tipogrupo", Schema = "empreendimento")]
    public class TipoGrupo : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(15), Required] public string Nome { get; set; }

        [NotMapped] public static TipoGrupo Quadra => new TipoGrupo(1, "Quadra");
        [NotMapped] public static TipoGrupo Andar => new TipoGrupo(2, "Andar");

        public TipoGrupo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoGrupo[] ObterDados()
        {
            return new TipoGrupo[]
            {
                Quadra,
                Andar
            };
        }
    }
}
