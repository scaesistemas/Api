using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras;


[Table("pedidoxmlarquivo", Schema = "compras")]
public class PedidoXMLArquivo : Arquivo, IEntity
{
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public string Descricao { get; set; }
}
