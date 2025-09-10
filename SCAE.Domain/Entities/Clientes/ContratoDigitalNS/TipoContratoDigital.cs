using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SCAE.Domain.Entities.Clientes.ContratoDigitalNS
{

    [Table("tipocontratodigital", Schema = "clientes")]
    public class TipoContratoDigital : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoContratoDigital CompraEVenda => new TipoContratoDigital(1, "Contratos de Compra e Venda");
        [NotMapped] public static TipoContratoDigital Aditivos => new TipoContratoDigital(2, "Aditivos");
        [NotMapped] public static TipoContratoDigital DocumentosComplementares => new TipoContratoDigital(3, "Documentos Complementares");


        public TipoContratoDigital(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoContratoDigital[] ObterDados()
        {
            return new TipoContratoDigital[]
            {
                    CompraEVenda,
                    Aditivos,
                    DocumentosComplementares

            };
        }
    }
}
