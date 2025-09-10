using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("unidade_proprietario", Schema = "empreendimento")]
    public class UnidadeProprietario : IEntity
    {
        public int Id { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
        public int ProprietarioId { get; set; }
        public Pessoa Proprietario { get; set; }
        public decimal Participacao { get; set; }
        public string Observacao { get; set; }
    }
}
