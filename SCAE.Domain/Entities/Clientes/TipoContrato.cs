using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes
{
    [Table("tipocontrato", Schema = "clientes")]
    public class TipoContrato : IEntity
    {
        public int Id { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        public int TipoOperacaoId { get; set; }
        public TipoOperacaoContrato TipoOperacao { get; set; }
    }
}
