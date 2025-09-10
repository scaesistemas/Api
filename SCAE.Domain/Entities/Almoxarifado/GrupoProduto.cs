using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Almoxarifado
{
    [Table("grupoproduto", Schema = "almoxarifado")]
    public class GrupoProduto : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [MaxLength(120), Required] public string Nome { get; set; }
    }
}
