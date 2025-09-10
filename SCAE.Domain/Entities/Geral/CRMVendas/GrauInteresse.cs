using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("grauinteresse", Schema = "geral")]
    public class GrauInteresse : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static GrauInteresse Quente => new GrauInteresse(1, "Quente");
       // [NotMapped] public static GrauInteresse Morno => new GrauInteresse(2, "Morno");
        [NotMapped] public static GrauInteresse Frio => new GrauInteresse(3, "Frio");


        public GrauInteresse(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static GrauInteresse[] ObterDados()
        {
            return new GrauInteresse[]
            {
                Quente,
              //  Morno,
                Frio
            };
        }
    }
}
