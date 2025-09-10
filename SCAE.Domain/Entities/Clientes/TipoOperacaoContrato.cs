using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes
{
    [Table("tipoOperacaocontrato", Schema = "clientes")]
    public class TipoOperacaoContrato : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoOperacaoContrato Venda => new TipoOperacaoContrato(1, "Venda");
        [NotMapped] public static TipoOperacaoContrato Locacao => new TipoOperacaoContrato(2, "Locação");
        [NotMapped] public static TipoOperacaoContrato Aditamento => new TipoOperacaoContrato(3, "Aditamento");

        public TipoOperacaoContrato(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoOperacaoContrato[] ObterDados()
        {
            return new TipoOperacaoContrato[]
            {
                Venda,
                Locacao,
                Aditamento
            };
        }
    }
}
