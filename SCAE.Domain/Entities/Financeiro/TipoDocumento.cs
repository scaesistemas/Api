using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("tipodocumento", Schema = "financeiro")]
    public class TipoDocumento : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
    }
}
