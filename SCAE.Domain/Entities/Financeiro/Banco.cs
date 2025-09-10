using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("banco", Schema = "financeiro")]
    public class Banco : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [Required] public int Codigo { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        [StringLength(100)] public string Site { get; set; }
    }
}
