using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("ladoadicional", Schema = "empreendimento")]
    public class LadoAdicional : IEntity
    {
        public int Id { get; set; }
        [StringLength(40)] public string Nome { get; set; }
        public decimal Valor  { get; set; }
        public int? EmpreendimentoId { get; set; }       
        public Empreendimento Empreendimento { get; set; }
        public int? LoteId { get; set; }
        public Lote Lote { get; set; }
    }
}
