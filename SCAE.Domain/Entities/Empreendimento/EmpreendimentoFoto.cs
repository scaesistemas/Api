using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("empreendimentofoto", Schema = "empreendimento")]
    public class EmpreendimentoFoto : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento Empreendimento { get; set; }
        public string Descricao { get; set; }
    }
}