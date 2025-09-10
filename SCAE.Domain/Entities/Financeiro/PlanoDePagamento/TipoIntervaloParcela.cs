using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro.PlanoDePagamento
{
    [Table("tipointervaloparcelas", Schema = "financeiro")]
    public class TipoIntervaloParcela : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoIntervaloParcela Mensal => new(1, "Mensal");
        [NotMapped] public static TipoIntervaloParcela Quinzenal => new(2, "Quinzenal");
        [NotMapped] public static TipoIntervaloParcela Bimestral => new(3, "Bimestral");
        [NotMapped] public static TipoIntervaloParcela Trimestral => new(4, "Trimestral");
        [NotMapped] public static TipoIntervaloParcela Quadrimestral => new(5, "Quadrimestral");
        [NotMapped] public static TipoIntervaloParcela Semestral => new(6, "Semestral");
        [NotMapped] public static TipoIntervaloParcela Anual => new(7, "Anual");



        public TipoIntervaloParcela(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoIntervaloParcela[] ObterDados()
        {
            return new TipoIntervaloParcela[]
            {
                Mensal,
                Quinzenal,
                Bimestral,
                Trimestral,
                Quadrimestral,
                Semestral,
                Anual

            };
        }

        public static TipoIntervaloParcela Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }
    }
}
