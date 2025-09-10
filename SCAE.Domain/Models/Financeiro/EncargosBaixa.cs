using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro
{
    public class EncargosBaixa
    {
        public decimal TaxaParcela { get; set; }
        public decimal MultaParcela { get; set; }
        public decimal JurosParcela { get; set; }
        public decimal Desconto { get; set; }
    }
}