using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto
{
    public class RemessaModel
    {
        public int Sequencia { get; set; }
        public List<BoletoModel> Boletos { get; set; }

        public RemessaModel()
        {
            Boletos = new List<BoletoModel>();
        }
    }
}
