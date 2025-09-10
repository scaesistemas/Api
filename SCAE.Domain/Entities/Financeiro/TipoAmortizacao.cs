using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace SCAE.Domain.Entities.Financeiro
{
    [Table("tipoAmortizacao", Schema = "financeiro")]
    public class TipoAmortizacao : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoAmortizacao Padrao => new TipoAmortizacao(1, "Padrão");
        [NotMapped] public static TipoAmortizacao Price => new TipoAmortizacao(2, "PRICE");
        [NotMapped] public static TipoAmortizacao Sac => new TipoAmortizacao(3, "SAC");

        public TipoAmortizacao(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoAmortizacao[] ObterDados()
        {
            return new TipoAmortizacao[]
            {
                Padrao,
                Price,
                Sac
            };
        }

        public static TipoAmortizacao Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }
    }
}

