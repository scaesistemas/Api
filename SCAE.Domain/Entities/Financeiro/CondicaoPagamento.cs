using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("condicaopagamento", Schema = "financeiro")]
    public class CondicaoPagamento : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        [Required] public int Parcelas { get; set; }
        [Required] public int Intervalo { get; set; }
    }
}
