using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("tipoimovel", Schema = "empreendimento")]
    public class TipoImovel : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoImovel Casa => new TipoImovel(1, "Casa");
        [NotMapped] public static TipoImovel Apartamento => new TipoImovel(2, "Apartamento");
        [NotMapped] public static TipoImovel Quitinete => new TipoImovel(3, "Quitinete");
        [NotMapped] public static TipoImovel Flat => new TipoImovel(4, "Flat");
        [NotMapped] public static TipoImovel Loft => new TipoImovel(5, "Loft");
        [NotMapped] public static TipoImovel Galpao => new TipoImovel(6, "Galpão");
        [NotMapped] public static TipoImovel Loja => new TipoImovel(7, "Loja");
        [NotMapped] public static TipoImovel Outro => new TipoImovel(8, "Outro");

        public TipoImovel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoImovel[] ObterDados()
        {
            return new TipoImovel[]
            {
                Casa,
                Apartamento,
                Quitinete,
                Flat,
                Loft,
                Galpao,
                Outro
            };
        }
    }
}
