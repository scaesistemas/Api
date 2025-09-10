using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes.ContratoDigitalNS
{
    [Table("situacaocontratodigital", Schema = "clientes")]

    public class SituacaoContratoDigital : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoContratoDigital EnvioPendente => new(1, "Envio pendente");
        [NotMapped] public static SituacaoContratoDigital AguardandoSignatarios => new(2, "Aguardando signatários");
        [NotMapped] public static SituacaoContratoDigital AguardandoAssinaturas => new (3, "Aguardando assinaturas");
        [NotMapped] public static SituacaoContratoDigital Finalizado => new (4, "Finalizado");
        [NotMapped] public static SituacaoContratoDigital Arquivado => new (5, "Arquivado");
        [NotMapped] public static SituacaoContratoDigital Cancelado => new (6, "Cancelado");
        [NotMapped] public static SituacaoContratoDigital Editando => new(7, "Editando");
        [NotMapped] public static SituacaoContratoDigital Processando => new(8, "Processando");


        public SituacaoContratoDigital(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static SituacaoContratoDigital[] ObterDados()
        {
            return new SituacaoContratoDigital[]
            {
                   EnvioPendente,
                   AguardandoSignatarios,
                   AguardandoAssinaturas,
                   Finalizado,
                   Arquivado,
                   Cancelado,
                   Editando,
                   Processando

            };
        }
    }
}
