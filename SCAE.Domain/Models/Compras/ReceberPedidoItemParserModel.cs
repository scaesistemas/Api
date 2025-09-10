using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Compras
{
    public class ReceberPedidoItemParserModel
    {
        public int? Id { get; set; }
        public int? AlmoxarifadoId { get; set; }
        public decimal Quantidade { get; set; }
    }
}
