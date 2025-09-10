using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("vicio", Schema = "empreendimento")]
    public class Vicio : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public string Nome { get; set; }
        public int? TipoUnidadeId { get; set; }
        public TipoUnidade TipoUnidade { get; set; }
    }
}
