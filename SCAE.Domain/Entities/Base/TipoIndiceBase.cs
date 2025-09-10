using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Base
{
    [Table("TipoIndiceBase", Schema = "base")]
    public class TipoIndiceBase : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoIndiceBase IGPM => new TipoIndiceBase(1, "IGP-M (FGV)");
        [NotMapped] public static TipoIndiceBase Selic => new TipoIndiceBase(2, "Selic");
        [NotMapped] public static TipoIndiceBase INCC => new TipoIndiceBase(3, "INCC (FGV)");
        [NotMapped] public static TipoIndiceBase INPC => new TipoIndiceBase(4, "INPC (IBGE)");
        [NotMapped] public static TipoIndiceBase ParcelaFixa => new TipoIndiceBase(5, "PARCELAS FIXAS");
        [NotMapped] public static TipoIndiceBase SalarioMinimo => new TipoIndiceBase(6, "SALÁRIO MÍNIMO");
        [NotMapped] public static TipoIndiceBase UFIR =>  new TipoIndiceBase(7, "UFIR");
        [NotMapped] public static TipoIndiceBase IPCA =>  new TipoIndiceBase(8, "IPCA");
        [NotMapped] public static TipoIndiceBase Outro => new TipoIndiceBase(9, "Outro");


        public TipoIndiceBase(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoIndiceBase[] ObterDados()
        {
            return new TipoIndiceBase[]
            {
                IGPM,
                Selic,
                INCC,
                INPC,
                ParcelaFixa,
                SalarioMinimo,
                UFIR,
                IPCA,
                Outro
            };
        }

        public static TipoIndiceBase ObterPorNome(string indice)
        {
            if (string.IsNullOrEmpty(indice))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == indice.ToUpper());
        }
    }
}
