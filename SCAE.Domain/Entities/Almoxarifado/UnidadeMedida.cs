using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Almoxarifado
{
    [Table("unidademedida", Schema = "almoxarifado")]
    public class UnidadeMedida : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [MaxLength(45), Required] public string Nome { get; set; }
        [MaxLength(6), Required] public string Sigla { get; set; }
    }
}
