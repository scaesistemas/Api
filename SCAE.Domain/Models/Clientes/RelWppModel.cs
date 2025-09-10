using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Clientes
{
    public class RelWppModel
    {
        public List<RelatorioWppModel> Lista { get; set; }
        public int TotalEnviados { get; set; }

        public RelWppModel()
        {
            Lista = new List<RelatorioWppModel>();
        }
    }

    public class RelatorioWppModel
    {
        public string NomeClienteECpf { get; set; }
        public int NumeroContrato { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime? DataEnvioCobranca { get; set; }
        public DateTime? DataEnvioWpp{ get; set; }
        public string NumeroTelefone { get; set; }
        public string EmpresaNome { get; set; }
    }
}
