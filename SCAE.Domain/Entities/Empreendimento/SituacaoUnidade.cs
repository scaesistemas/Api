using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("situacaounidade", Schema = "empreendimento")]
    public class SituacaoUnidade : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoUnidade Disponivel => new (1, "Disponível");
        [NotMapped] public static SituacaoUnidade Indisponivel => new (2, "Indisponível");
        [NotMapped] public static SituacaoUnidade Vendido => new (3, "Vendido");
        [NotMapped] public static SituacaoUnidade Reservado => new (4, "Reservado");
        [NotMapped] public static SituacaoUnidade Invadido => new (5, "Invadido");
        [NotMapped] public static SituacaoUnidade Penhorado => new (6, "Penhorado");
        [NotMapped] public static SituacaoUnidade Caucionado => new(7, "Caucionado");

        public SituacaoUnidade(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static SituacaoUnidade[] ObterDados()
        {
            return new SituacaoUnidade[]
            {
                Disponivel,
                Indisponivel,
                Vendido,
                Reservado,
                Invadido,
                Penhorado,
                Caucionado
            };
        }

        public static SituacaoUnidade ObterPorNome(string situacaoUnidade)
        {
            if (string.IsNullOrEmpty(situacaoUnidade))
                return null;

            return ObterDados()
                    .SingleOrDefault(x => x.Nome.ToUpper() == situacaoUnidade.ToUpper());
        }
    }
}
