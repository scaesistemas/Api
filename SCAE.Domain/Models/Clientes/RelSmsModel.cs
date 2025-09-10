using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Clientes
{
    public class RelSmsModel
    { 
        public List<RelatorioSmsModel> Lista { get; set; }
        public int TotalEnviados { get; set; }
         
        public RelSmsModel()
        {
            Lista = new List<RelatorioSmsModel>();
        }
    }

    public class RelatorioSmsModel
    {
        public string NomeClienteECpf { get; set; }
        public int NumeroContrato { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime? DataEnvioCobranca { get; set; }
        public DateTime? DataEnvioSms { get; set; }
        public string NumeroTelefone { get; set; }
        public string EmpresaNome { get; set; }
    }
}
