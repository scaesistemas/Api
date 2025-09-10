using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("tipounidade", Schema = "empreendimento")]
    public class TipoUnidade : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(15), Required] public string Nome { get; set; }

        [NotMapped] public static TipoUnidade Lote => new TipoUnidade(1, "Lote");
        [NotMapped] public static TipoUnidade Imovel => new TipoUnidade(2, "Imóvel");
        [NotMapped] public static TipoUnidade Jazigos => new TipoUnidade(3, "Jazigo");

        public TipoUnidade(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoUnidade[] ObterDados()
        {
            return new TipoUnidade[]
            {
                Lote,
                Imovel,
                Jazigos
            };
        }

        public static TipoUnidade ObterPorNome(string tipoUnidade)
        {
            if (string.IsNullOrEmpty(tipoUnidade))
                return null;

            return ObterDados()
                    .SingleOrDefault(x => x.Nome.ToUpper() == tipoUnidade.ToUpper());
        }
    }
}
