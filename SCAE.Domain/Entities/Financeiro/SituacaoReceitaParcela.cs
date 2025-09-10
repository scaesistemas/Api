using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("situacaoreceitaparcela", Schema = "financeiro")]
    public class SituacaoReceitaParcela : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoReceitaParcela Aberto => new SituacaoReceitaParcela(1, "Aberto");
        [NotMapped] public static SituacaoReceitaParcela Cancelado => new SituacaoReceitaParcela(2, "Cancelado");
        [NotMapped] public static SituacaoReceitaParcela Pago => new SituacaoReceitaParcela(3, "Pago");
        [NotMapped] public static SituacaoReceitaParcela PagoParcialmente => new SituacaoReceitaParcela(4, "Pago Parcialmente");
        [NotMapped] public static SituacaoReceitaParcela Aditado => new SituacaoReceitaParcela(5, "Aditado");
        [NotMapped] public static SituacaoReceitaParcela Amortizado => new SituacaoReceitaParcela(6, "Amortizado");
        [NotMapped] public static SituacaoReceitaParcela AmortizadoPendente => new SituacaoReceitaParcela(7, "Amortizado Pendente");
        [NotMapped] public static SituacaoReceitaParcela PendenteAprovacao => new SituacaoReceitaParcela(8, "Pendente de aprovação");


        public SituacaoReceitaParcela(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static SituacaoReceitaParcela[] ObterDados()
        {
            return new SituacaoReceitaParcela[]
            {
                Aberto,
                Cancelado,
                Pago,
                PagoParcialmente,
                Aditado,
                Amortizado,
                AmortizadoPendente,
                PendenteAprovacao
            };
        }

        public static SituacaoReceitaParcela ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
    }
}
