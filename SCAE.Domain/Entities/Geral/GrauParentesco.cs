using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace SCAE.Domain.Entities.Geral
{
    [Table("grauparentesco", Schema = "geral")]
    public class GrauParentesco : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static GrauParentesco Pai => new GrauParentesco(1, "Pai");
        [NotMapped] public static GrauParentesco Mae => new GrauParentesco(2, "Mãe");
        [NotMapped] public static GrauParentesco AvoMasculino => new GrauParentesco(3, "Avô");
        [NotMapped] public static GrauParentesco AvoFeminino => new GrauParentesco(4, "Avó");
        [NotMapped] public static GrauParentesco BisavoMasculino => new GrauParentesco(5, "Bisavô");
        [NotMapped] public static GrauParentesco BisavoFeminino => new GrauParentesco(6, "Bisavó");
        [NotMapped] public static GrauParentesco Filho => new GrauParentesco(7, "Filho");
        [NotMapped] public static GrauParentesco Filha => new GrauParentesco(8, "Filha");
        [NotMapped] public static GrauParentesco Neto => new GrauParentesco(9, "Neto");
        [NotMapped] public static GrauParentesco Neta => new GrauParentesco(10, "Neta");
        [NotMapped] public static GrauParentesco Bisneto => new GrauParentesco(11, "Bisneto");
        [NotMapped] public static GrauParentesco Bisneta => new GrauParentesco(12, "Bisneta");
        [NotMapped] public static GrauParentesco Irmao => new GrauParentesco(13, "Irmão");
        [NotMapped] public static GrauParentesco Irma => new GrauParentesco(14, "Irmã");
        [NotMapped] public static GrauParentesco Tio => new GrauParentesco(15, "Tio");
        [NotMapped] public static GrauParentesco Tia => new GrauParentesco(16, "Tia");
        [NotMapped] public static GrauParentesco Sobrinho => new GrauParentesco(17, "Sobrinho");
        [NotMapped] public static GrauParentesco Sobrinha => new GrauParentesco(18, "Sobrinha");
        [NotMapped] public static GrauParentesco Primo => new GrauParentesco(19, "Primo");
        [NotMapped] public static GrauParentesco Prima => new GrauParentesco(20, "Prima");
        [NotMapped] public static GrauParentesco Sogro => new GrauParentesco(21, "Sogro");
        [NotMapped] public static GrauParentesco Sogra => new GrauParentesco(22, "Sogra");
        [NotMapped] public static GrauParentesco Cunhado => new GrauParentesco(23, "Cunhado");
        [NotMapped] public static GrauParentesco Cunhada => new GrauParentesco(24, "Cunhada");
        [NotMapped] public static GrauParentesco Outro => new GrauParentesco(25, "Outro");


        public GrauParentesco(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static GrauParentesco[] ObterDados()
        {
            return new GrauParentesco[]
            {
                Pai,
                Mae,
                AvoMasculino,
                AvoFeminino,
                BisavoMasculino,
                BisavoFeminino,
                Filho,
                Filha,
                Neto,
                Neta,
                Bisneto,
                Bisneta,
                Irmao,
                Irma,
                Tio,
                Tia,
                Sobrinho,
                Sobrinha,
                Primo,
                Prima,
                Sogro,
                Sogra,
                Cunhado,
                Cunhada,
                Outro
            };
        }

        public static GrauParentesco ObterPorNome(string grauparentesco)
        {
            if (string.IsNullOrEmpty(grauparentesco))
                return null;

            return ObterDados()
                    .SingleOrDefault(x => x.Nome.ToUpper() == grauparentesco.ToUpper() ||
                    x.Nome.Replace("o(a)", "a").ToUpper() == grauparentesco.ToUpper() ||
                    x.Nome.Replace("(a)", "").ToUpper() == grauparentesco.ToUpper());
        }
    }
}
