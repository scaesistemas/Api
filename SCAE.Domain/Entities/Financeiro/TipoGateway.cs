using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("tipogateway", Schema = "financeiro")]
    public class TipoGateway : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoGateway Zoop => new TipoGateway(1, "Zoop");
        [NotMapped] public static TipoGateway GalaxPay => new TipoGateway(2, "GalaxPay");
        [NotMapped] public static TipoGateway Safra => new TipoGateway(3, "Safra");
        [NotMapped] public static TipoGateway Asaas => new TipoGateway(4, "Asaas");
        [NotMapped] public static TipoGateway ContaPay => new TipoGateway(5, "ContaPay");
        [NotMapped] public static TipoGateway Global => new TipoGateway(6, "Global");
        public TipoGateway(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoGateway[] ObterDados()
        {
            return new TipoGateway[]
            {
                Zoop,
                GalaxPay,
                Safra,
                Asaas,
                ContaPay,
                Global
            };
        }
    }
}
