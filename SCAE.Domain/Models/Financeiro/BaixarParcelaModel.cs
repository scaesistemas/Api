
using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro
{ 
    public class BaixarParcelaModel
    {
        public List<int> ParcelaIds { get; set; }
        public ReceitaBaixa ModeloBaixa { get; set; } 

        public bool PagarNoVencimento { get; set; }
    }
}
