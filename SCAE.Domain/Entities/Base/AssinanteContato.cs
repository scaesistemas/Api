using SCAE.Domain.Entities.Shared;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Base
{
    [Table("assinantecontato", Schema = "base")]
    public class AssinanteContato : Contato, IEntity
    {
        public int Id { get; set; }
        public int AssinanteId { get; set; }
        public string Observacao { get; set; }
        [Required] public bool Principal { get; set; }
    }
}
