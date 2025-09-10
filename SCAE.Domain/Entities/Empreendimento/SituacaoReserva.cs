using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("situacaoreserva", Schema = "empreendimento")]
    public class SituacaoReserva : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoReserva EmAndamento => new(1, "Em andamento");
        [NotMapped] public static SituacaoReserva AguardandoAprovacaoVenda => new(2, "Aguardando aprovação da venda");
        [NotMapped] public static SituacaoReserva Vendido => new(3, "Vendido");
        [NotMapped] public static SituacaoReserva Cancelado => new(4, "Cancelado");
        [NotMapped] public static SituacaoReserva PropostaDevolvida => new(5, "Proposta devolvida");


        public SituacaoReserva(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public static SituacaoReserva[] ObterDados()
        {
            return new SituacaoReserva[]
            {
                EmAndamento,
                AguardandoAprovacaoVenda,
                Vendido,
                Cancelado,
                PropostaDevolvida
            };
        }
    }
}
