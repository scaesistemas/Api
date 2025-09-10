using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Geral
{
    [Owned]
    public class RegistroImportacao
    {
        public int? CodOrigem { get; set; }
        public DateTime? DataImportacao { get; set; }
        public string NomePlanilha { get; set; }
    }
}
