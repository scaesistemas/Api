using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain
{
    [Owned]
    public class Bancario
    {
        [StringLength(40)] public string Banco { get; set; }
        [StringLength(10)] public string Agencia { get; set; }
        [StringLength(2)] public string AgenciaDigito { get; set; }
        [StringLength(10)] public string Conta { get; set; }
        [StringLength(2)] public string ContaDigito { get; set; }
        public string Pix { get; set; }
    }
}
