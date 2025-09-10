using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("situacaodespesaparcela", Schema = "financeiro")]
    public class SituacaoDespesaParcela : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoDespesaParcela Aberto => new SituacaoDespesaParcela(1, "Aberto");
        [NotMapped] public static SituacaoDespesaParcela Cancelado => new SituacaoDespesaParcela(2, "Cancelado");
        [NotMapped] public static SituacaoDespesaParcela Pago => new SituacaoDespesaParcela(3, "Pago");
        [NotMapped] public static SituacaoDespesaParcela PagoParcialmente => new SituacaoDespesaParcela(4, "Pago Parcialmente");

        public SituacaoDespesaParcela(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static SituacaoDespesaParcela[] ObterDados()
        {
            return new SituacaoDespesaParcela[]
            {
                Aberto,
                Cancelado,
                Pago,
                PagoParcialmente
            };
        }

        public static SituacaoDespesaParcela ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
    }
}
