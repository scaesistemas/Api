using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro
{

    [Table("tipoOperacaofinanceira", Schema = "financeiro")]
    public class TipoOperacaoFinanceira : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoOperacaoFinanceira Gateway => new TipoOperacaoFinanceira(1, "Fintech");
        [NotMapped] public static TipoOperacaoFinanceira Boleto => new TipoOperacaoFinanceira(2, "Banco Arquivo");
        [NotMapped] public static TipoOperacaoFinanceira Banco => new TipoOperacaoFinanceira(3, "Banco Integrado");


        public TipoOperacaoFinanceira(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoOperacaoFinanceira[] ObterDados()
        {
            return new TipoOperacaoFinanceira[]
            {
                Gateway,
                Boleto,
                Banco
            };
        }

        public static TipoOperacaoFinanceira Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }
    }
}
