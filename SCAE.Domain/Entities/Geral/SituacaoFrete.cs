using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("situacaofrete", Schema = "geral")]
    public class SituacaoFrete : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoFrete Incluso => new SituacaoFrete(1, "Incluso");
        [NotMapped] public static SituacaoFrete Separado => new SituacaoFrete(2, "Separado");
        [NotMapped] public static SituacaoFrete SemFrete => new SituacaoFrete(3, "Sem Frete");

        public SituacaoFrete(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static SituacaoFrete[] ObterDados()
        {
            return new SituacaoFrete[]
            {
                Incluso,
                Separado,
                SemFrete
            };
        }
    }
}
