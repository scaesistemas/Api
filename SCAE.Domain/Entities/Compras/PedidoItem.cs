using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras
{
    [Table("pedidoitem", Schema = "compras")]
    public class PedidoItem : IEntity
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int SituacaoId { get; set; }
        public SituacaoPedidoItem Situacao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal QuantidadeRecebida { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Total => Quantidade * ValorUnitario;
        public decimal TotalRecebido => QuantidadeRecebida * ValorUnitario;
        public decimal QuantidadeAReceber => Quantidade - QuantidadeRecebida;

        public PedidoItem()
        {
            SituacaoId = SituacaoPedidoItem.Pendente.Id;
        }

    }
}
