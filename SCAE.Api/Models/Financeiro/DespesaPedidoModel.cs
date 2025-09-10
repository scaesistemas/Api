using SCAE.Domain.Entities.Compras;
using SCAE.Domain.Entities.Financeiro;
using System.Collections.Generic;

namespace SCAE.Api.Models.Financeiro
{
    public class DespesaPedidoModel
    {
        public Despesa Despesa { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}
