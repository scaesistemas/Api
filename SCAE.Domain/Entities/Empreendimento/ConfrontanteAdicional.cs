using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("confrontanteadicional", Schema = "empreendimento")]

    public class ConfrontanteAdicional : IEntity
    {
        public int Id { get; set; }
        [StringLength(60)] public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int? UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
    }
}
