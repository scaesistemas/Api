using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Shared;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.Geral
{
    [Owned]
    public class EmpresaResponsavel : PessoaFisica
    {
        [MaxLength(60)] public string Sobrenome { get; set; }
        public string NomeCompleto => $"{Nome} {Sobrenome}";
        public int CodigoCategoriaComerciante { get; set; }
        [MaxLength(80)] public string CategoriaComerciante { get; set; }
        [MaxLength(45)] public string CodigoZoop { get; set; }
        


        public EmpresaResponsavel() : base()
        {

        }
    }
}
