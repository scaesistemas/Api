using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes.ContratoDigitalNS
{
    [Table("tipoassinatura", Schema = "clientes")]
    public class TipoAssinatura : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoAssinatura Parte => new TipoAssinatura(1, "Assinar como parte");
        [NotMapped] public static TipoAssinatura Testemunha => new TipoAssinatura(2, "Assinar como testemunha");
        [NotMapped] public static TipoAssinatura Avalista => new TipoAssinatura(3, "Assinar como avalista"); // id 9 D4Sign


        public TipoAssinatura(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoAssinatura[] ObterDados()
        {
            return new TipoAssinatura[]
            {
                    Parte,
                    Testemunha,
                    Avalista
            };
        }
    }
}
