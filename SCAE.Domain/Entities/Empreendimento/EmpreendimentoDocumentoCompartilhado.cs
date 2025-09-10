using System.ComponentModel.DataAnnotations.Schema;
using SCAE.Domain.Interfaces.Shared;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("empreendimentoDocumentoCompartilhado", Schema = "empreendimento")]
    public class EmpreendimentoDocumentoCompartilhado : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento Empreendimento { get; set; }
        public string Descricao { get; set; }
    }
}