using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Clientes
{
    public class ContratoModel
    {   

        public int Id { get; set; }
        public string NumeroSequencia { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string GrupoNome { get; set; }
        public string LoteNome { get; set;}
        public byte[] FotoEmpreendimento { get; set; }

    }
}
