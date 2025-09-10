using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro
{
    public class AtualizarDataSequenciaModel
    {
        public int Id { get; set; }
        public int NumeroParcela { get; set; }
        //public int ParcelaId { get; set; }
        public DateTime DataInicial { get; set; }
    }
}
