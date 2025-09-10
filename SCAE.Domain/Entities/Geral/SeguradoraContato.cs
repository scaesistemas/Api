using SCAE.Domain.Entities.Shared;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("seguradora_contato", Schema = "loteamento")]
    public class SeguradoraContato : Contato, IEntity
    {
        public int Id { get; set; }
        public int SeguradoraId { get; set; }
    }
}
