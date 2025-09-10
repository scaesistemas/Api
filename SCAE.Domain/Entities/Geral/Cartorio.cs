using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("cartorio", Schema = "geral")]
    public class Cartorio : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [StringLength(25), Required] public string Nome { get; set; }
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public string Descricao => $"{Nome} - {Municipio?.Nome} - {Estado?.Nome}";
    }
}
