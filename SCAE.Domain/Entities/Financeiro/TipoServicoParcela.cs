using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("tiposervico", Schema = "financeiro")]
    public class TipoServicoParcela : IEntity
    {
            public int Id { get; set; }
            [StringLength(60)]  public string Nome { get; set; }
            public decimal Valor { get; set; }
    }
}
