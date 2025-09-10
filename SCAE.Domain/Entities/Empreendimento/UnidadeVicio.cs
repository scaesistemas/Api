using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("unidadevicio", Schema = "empreendimento")]
    public class UnidadeVicio : IEntity
    {
        public int Id { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
        public int VicioId { get; set; }
        public Vicio Vicio { get; set; }
    }
}
