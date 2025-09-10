using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Base
{
    [Table("SplitPagamentoBase", Schema = "base")]
    public class SplitPagamentoBase
    {
        public int Id { get; set; }
        public int AdiantamentoCarteiraId { get; set; }
        public AdiantamentoCarteira AdiantamentoCarteira { get; set; }
        public string EmpresaNome { get; set; }
        public int? GalaxyId { get; set; }
        public bool IsPercentual { get; set; }
        public decimal valor { get; set; }
    }
}
