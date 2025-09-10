using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Clientes.ContratoDigitalNS
{
    public class RetornoWebHookModel
    {
        public string DocumentoID { get; set; }
        public string TipoRetorno { get; set; }
        public string Mensagem { get; set; }
        public string Email { get; set; }
    }
}
