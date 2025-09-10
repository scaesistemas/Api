using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Clientes
{
    public class RelCobrancaModel
    {
        public List<RelatorioCobrancaModel> Lista { get; set; }
        public int TotalEnviadosCobrancaEmail { get; set; }
        public int TotalEnviadosCobrancaSms { get; set; }
        public int TotalEnviadosCobrancaWpp { get; set; }


        public RelCobrancaModel()
        {
            Lista = new List<RelatorioCobrancaModel>();
        }
    }

    public class RelatorioCobrancaModel
    {
        public string ClienteNome { get; set; }
        public string NumeroContrato { get; set; }
        public int NumeroParcela { get; set; }
        public string EmpresaNome { get; set; }
        public string EmpreendimentoNome { get; set;}
        public DateTime? DataEnvioCobranca { get; set; }
        public string ClienteTelefone { get; set; }    
        public DateTime? DataEnvioSms { get; set; }
        public DateTime? DataEnvioWpp { get; set; }
    }
}
