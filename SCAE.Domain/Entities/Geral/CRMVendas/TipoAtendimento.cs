using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("tipoatendimento", Schema = "geral")]
    public class TipoAtendimento : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(40), Required] public string Nome { get; set; }

        [NotMapped] public static TipoAtendimento Email => new(1, "Email");
        [NotMapped] public static TipoAtendimento Ligacao => new(2, "Ligação");
        [NotMapped] public static TipoAtendimento Observacao => new(3, "Observação");
        [NotMapped] public static TipoAtendimento Visita => new(4, "Visita");
        [NotMapped] public static TipoAtendimento Whatsapp => new(5, "Whatsapp" );


        public TipoAtendimento()
        {

        }
        public TipoAtendimento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoAtendimento[] ObterDados()
        {
            return new TipoAtendimento[]
            {
                Email,
                Ligacao,
                Observacao,
                Visita,
                Whatsapp
            };
        }
    }
}
