using SCAE.Domain.Entities.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Financeiro
{
    public class EtapaReguaContrato
    {
        public int Id { get; set; }
        public String Numero { get; set; }
        
        public int QuantidadeParcela { get; set; }
        public DateTime ParcelaMaisAntiga { get; set; }


    }
}