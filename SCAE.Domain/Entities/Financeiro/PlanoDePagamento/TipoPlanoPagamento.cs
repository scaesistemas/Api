using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro.PlanoDePagamento
{
    [Table("tipoplanopagamento", Schema = "financeiro")]
    public class TipoPlanoPagamento : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoPlanoPagamento MetroQuadrado => new (1, "M²");
        [NotMapped] public static TipoPlanoPagamento ValorFixo => new (2, "Valor Fixo");
        [NotMapped] public static TipoPlanoPagamento PercentualValorTotal => new (3, "% Valor Total");


        public TipoPlanoPagamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoPlanoPagamento[] ObterDados()
        {
            return new TipoPlanoPagamento[]
            {
                MetroQuadrado,
                ValorFixo,
                PercentualValorTotal
            };
        }

        public static TipoPlanoPagamento Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }
    }
}

