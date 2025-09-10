using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SCAE.Domain.Interfaces.Shared;

namespace SCAE.Domain.Entities.Geral.ModuloPrefeitura
{
    [Table("tipoedificacaomoradia", Schema = "geral")]
    public class TipoEdificacaoMoradia : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoEdificacaoMoradia Apartamento => new TipoEdificacaoMoradia(1, "Apartamento");
        [NotMapped] public static TipoEdificacaoMoradia Barraco => new TipoEdificacaoMoradia(2, "Barraco");
        [NotMapped] public static TipoEdificacaoMoradia CasaTerreo => new TipoEdificacaoMoradia(3, "Casa térreo");
        [NotMapped] public static TipoEdificacaoMoradia AreaRisco => new TipoEdificacaoMoradia(4, "Construção em área de risco");
        [NotMapped] public static TipoEdificacaoMoradia TerrenoIrregular => new TipoEdificacaoMoradia(5, "Construção em terreno irregular");
        [NotMapped] public static TipoEdificacaoMoradia ConstrucaoMista => new TipoEdificacaoMoradia(6, "Construção mista");
        [NotMapped] public static TipoEdificacaoMoradia HabitacaoColetiva => new TipoEdificacaoMoradia(7, "Habitação coletiva");
        [NotMapped] public static TipoEdificacaoMoradia Palafita => new TipoEdificacaoMoradia(8, "Palafita");
        [NotMapped] public static TipoEdificacaoMoradia Sobrado => new TipoEdificacaoMoradia(9, "Sobrado");
        [NotMapped] public static TipoEdificacaoMoradia Outra => new TipoEdificacaoMoradia(10, "Outros");


        public TipoEdificacaoMoradia(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoEdificacaoMoradia[] ObterDados()
        {
            return new TipoEdificacaoMoradia[]
            {
                Apartamento,
                Barraco,
                CasaTerreo,
                AreaRisco,
                TerrenoIrregular,
                ConstrucaoMista,
                HabitacaoColetiva,
                Palafita,
                Sobrado,
                Outra
            };
        }

        public static TipoEdificacaoMoradia ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
        public static TipoEdificacaoMoradia ObterPorId(int id)
        {
            if (id == null)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }
    }
}
