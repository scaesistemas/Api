using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("tipoprocessojudicial", Schema = "geral")]
    public class TipoProcessoJudicial : IEntity
    {
        public int Id { get; set; }
        [MaxLength(60), Required] public string Nome { get; set; }
    }
}
