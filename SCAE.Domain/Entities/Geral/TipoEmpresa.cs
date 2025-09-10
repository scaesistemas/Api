using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("tipoempresa", Schema = "geral")]
    public class TipoEmpresa : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoEmpresa Incorporadora => new (1, "Incorporadora");
        [NotMapped] public static TipoEmpresa SPE => new (2, "SPE");
        [NotMapped] public static TipoEmpresa SCP => new(3, "SCP");
        [NotMapped] public static TipoEmpresa Construtora => new(4, "Construtora");
        [NotMapped] public static TipoEmpresa IncorporadoraConstrutora => new(5, "Incorporadora e Construtora");
        [NotMapped] public static TipoEmpresa Outros => new(6, "Outros");

        [NotMapped] public static TipoEmpresa Ltda => new(7, "Ltda");
    
        [NotMapped] public static TipoEmpresa Imobiliaria => new(8, "Imobiliária");
    
        [NotMapped] public static TipoEmpresa Urbanizadora => new(9, "Urbanizadora");


        public TipoEmpresa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoEmpresa[] ObterDados()
        {
            return new TipoEmpresa[]
            {
                Incorporadora,
                SPE,
                SCP,
                Construtora,
                IncorporadoraConstrutora,
                Outros,
                Ltda,
                Imobiliaria,
                Urbanizadora
            };
        }
    }
}
