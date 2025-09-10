using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("layoutcobranca", Schema = "financeiro")]
    public class LayoutCobranca : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(60)] [Required] public string Nome { get; set; }
        [NotMapped] public static LayoutCobranca DiasAntes10 => new (1, "Seu boleto está disponível (10 dias antes)");
        [NotMapped] public static LayoutCobranca DiasAntes03 => new (2, "Seu boleto está disponível (3 dias antes)");
        [NotMapped] public static LayoutCobranca DiasDepois03 => new (3, "Pagamento atrasado (3 dias depois)");
        [NotMapped] public static LayoutCobranca DiasDepois10 => new (4, "Pagamento atrasado (10 dias depois)");
        [NotMapped] public static LayoutCobranca DiasDepois17 => new (5, "Pagamento atrasado (17 dias depois)");
        [NotMapped] public static LayoutCobranca DiasDepois26 => new (6, "Pagamento atrasado (26 dias depois)");
        [NotMapped] public static LayoutCobranca DiasDepois32 => new (7, "Pagamento atrasado (32 dias depois)");
        [NotMapped] public static LayoutCobranca DiasDepois46 => new (8, "Pagamento atrasado (46 dias depois)");
        [NotMapped] public static LayoutCobranca DiasDepois62 => new (9, "Pagamento atrasado (62 dias depois)");
        [NotMapped] public static LayoutCobranca DiasDepois74 => new (10, "Pagamento atrasado (74 dias depois)");
        [NotMapped] public static LayoutCobranca DiasDepois88 => new (11, "Pagamento atrasado (88 dias depois)");
        [NotMapped] public static LayoutCobranca DiasDepois94 => new (12, "Pagamento atrasado (94 dias depois)");
        [NotMapped] public static LayoutCobranca AVencerPadrao => new(13, "Pagamento a vencer");
        [NotMapped] public static LayoutCobranca VencidoPadrao => new(14, "Pagamento vencido");

        public LayoutCobranca(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static LayoutCobranca[] ObterDados()
        {
            return new LayoutCobranca[]
            {
                DiasAntes10,
                DiasAntes03,
                DiasDepois03,
                DiasDepois10,
                DiasDepois17,
                DiasDepois26,
                DiasDepois32,
                DiasDepois46,
                DiasDepois62,
                DiasDepois74,
                DiasDepois88,
                DiasDepois94,
                AVencerPadrao,
                VencidoPadrao
            };
        }
    }
}
