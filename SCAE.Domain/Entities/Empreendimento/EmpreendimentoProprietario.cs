using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("empreendimento_proprietario", Schema = "geral")]
    public class EmpreendimentoProprietario : IEntity
    {
        public int Id { get; set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento Empreendimento { get; set; }
        public int ProprietarioId { get; set; }
        public Pessoa Proprietario { get; set; }
        public decimal Participacao { get; set; }
        public string Observacao { get; set; }
    }
}
