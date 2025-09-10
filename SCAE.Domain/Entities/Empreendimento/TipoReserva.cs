using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("tiporeserva", Schema = "empreendimento")]
    public class TipoReserva : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoReserva Padrao => new TipoReserva(1, "Reserva Padrão");
        [NotMapped] public static TipoReserva PreReserva => new TipoReserva(2, "Pré-reserva");

        public TipoReserva(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public static TipoReserva[] ObterDados()
        {
            return new TipoReserva[]
            {
                Padrao,
                PreReserva
            };
        }
    }
}
