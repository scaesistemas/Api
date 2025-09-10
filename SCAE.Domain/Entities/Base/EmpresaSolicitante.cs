using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Base
{
    [Owned]
    public class EmpresaSolicitante
    {
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }

    }
}
