using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras
{
    [Table("pedidoclassificacao", Schema = "compras")]
    public class PedidoClassificacao : IEntity
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int CentroCustoId { get; set; }
        public CentroCusto CentroCusto { get; set; }
        public int ContaGerencialId { get; set; }
        public ContaGerencial ContaGerencial { get; set; }
        [Required] public decimal Valor { get; set; }
        [Required] public decimal Percentual { get; set; }
    }
}
