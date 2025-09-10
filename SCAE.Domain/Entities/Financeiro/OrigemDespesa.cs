using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("origemdespesa", Schema = "financeiro")]
    public class OrigemDespesa : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        [NotMapped] public static OrigemDespesa Contrato => new OrigemDespesa(1, "Contrato");
        [NotMapped] public static OrigemDespesa Documentacao => new OrigemDespesa(2, "Documentação");
        [NotMapped] public static OrigemDespesa Financeiro => new OrigemDespesa(3, "Financeiro");
        [NotMapped] public static OrigemDespesa PedidoCompra => new OrigemDespesa(4, "Pedido de Compra");
        [NotMapped] public static OrigemDespesa Servico => new OrigemDespesa(5, "Serviço");
        public OrigemDespesa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static OrigemDespesa[] ObterDados()
        {
            return new OrigemDespesa[]
            {
                Contrato,
                Documentacao,
                Financeiro,
                PedidoCompra,
                Servico
            };
        }
    }
}
