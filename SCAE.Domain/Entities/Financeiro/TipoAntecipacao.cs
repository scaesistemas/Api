using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("tipoantecipacao", Schema = "financeiro")]
    public class TipoAntecipacao : IEntity
    {

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoAntecipacao ValorParcelas => new TipoAntecipacao(1, "Reduzir valor das parcelas");
        [NotMapped] public static TipoAntecipacao PrazoContrato => new TipoAntecipacao(2, "Reduzir prazo do contrato");

        public TipoAntecipacao(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoAntecipacao[] ObterDados()
        {
            return new TipoAntecipacao[]
            {
                ValorParcelas,
                PrazoContrato
            };
        }

        public static TipoAntecipacao Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }

    }
}
