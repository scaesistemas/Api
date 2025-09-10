using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Geral;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain
{
    [Owned]
    public class Endereco
    {
        [StringLength(09)] public string Cep { get; set; }
        [StringLength(80), Required] public string Logradouro { get; set; }
        [StringLength(60)] public string Numero { get; set; }
        [StringLength(60)] public string Complemento { get; set; }
        [StringLength(100)] public string Bairro { get; set; }
        public int? MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public int? EstadoId { get; set; }
        public Estado Estado { get; set; }

        public Endereco()
        {
            Logradouro = "";
        }
        
    }
}
