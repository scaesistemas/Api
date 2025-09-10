using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SCAE.Domain.Interfaces.Shared;

namespace SCAE.Domain.Entities.Geral.ModuloPrefeitura
{
    [Table("tipomoradianova", Schema = "geral")]
    public class TipoMoradiaNova : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoMoradiaNova LoteUrbanizado => new TipoMoradiaNova(1, "Lote Urbanizado");
        [NotMapped] public static TipoMoradiaNova CasaConstruida => new TipoMoradiaNova(2, "Casa construída");
        [NotMapped] public static TipoMoradiaNova ApartamentoNovo => new TipoMoradiaNova(3, "Apartamento Novo");
        [NotMapped] public static TipoMoradiaNova Outra => new TipoMoradiaNova(4, "Outra");


        public TipoMoradiaNova(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoMoradiaNova[] ObterDados()
        {
            return new TipoMoradiaNova[]
            {
                 LoteUrbanizado,
                 CasaConstruida,
                 ApartamentoNovo,
                 Outra
            };
        }

        public static TipoMoradiaNova ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
        public static TipoMoradiaNova ObterPorId(int id)
        {
            if (id == null)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }
    }
}
