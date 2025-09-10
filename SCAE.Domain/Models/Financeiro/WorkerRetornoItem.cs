using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro
{
    public class WorkerRetornoItem
    {
        public string Log { get; set; }
        public int ParcelaId { get; set; } = 0;
        public int TransacaoId { get; set; } = 0;
        public bool IsErro { get; set; } = false;
    }
}