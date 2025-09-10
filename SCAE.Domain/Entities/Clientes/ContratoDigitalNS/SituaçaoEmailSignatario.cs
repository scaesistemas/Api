using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SCAE.Domain.Entities.Clientes.ContratoDigitalNS
{
    [Table("situacaoemailsignatario", Schema = "clientes")]
    public class SituacaoEmailSignatario : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoEmailSignatario Assinado => new(1, "Assinado");
        [NotMapped] public static SituacaoEmailSignatario Pendente => new(2, "Pendente");
        [NotMapped] public static SituacaoEmailSignatario NaoEnviado => new(3, "Não enviado");

        public SituacaoEmailSignatario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static SituacaoEmailSignatario[] ObterDados()
        {
            return new SituacaoEmailSignatario[]
            {
                    Assinado,
                    Pendente,
                    NaoEnviado
            };
        }
    }
}
