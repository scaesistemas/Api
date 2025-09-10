using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Base
{
    [Owned]
    public class AssinanteTermo
    {
        public int? TermosDeUsoId { get; set; }
        public TermosDeUso TermosDeUso { get; set; }
        public DateTime? DataAssinatura { get; set; }
        public DateTime? DataPrimeiraAssinatura { get; set; }
    }
}
