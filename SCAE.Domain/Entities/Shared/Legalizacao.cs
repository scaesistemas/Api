using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Geral;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.Shared
{
    [Owned]
    public class Legalizacao
    {
        [MaxLength(20)] public string Matricula { get; set; }
        [MaxLength(20)] public string Rgi { get; set; }
        [MaxLength(45)] public string NumeroProcesso { get; set; }
        [MaxLength(45)] public string OrgaoEmissor { get; set; }
        [MaxLength(15)] public string LivroNumero { get; set; }
        [MaxLength(15)] public string EscrituraLavrada { get; set; }
        [MaxLength(25)] public string IncricaoCadastral { get; set; }
        public int? CartorioId { get; set; }
        public Cartorio Cartorio { get; set; }
        public string Observacao { get; set; }
    }
}
