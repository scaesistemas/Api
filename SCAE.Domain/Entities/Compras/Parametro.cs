using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras
{
    [Table("parametro", Schema = "compras")]
    public class Parametro : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int AlmoxarifadoPadraoId { get; set; }
        public Almoxarifado.Almoxarifado AlmoxarifadoPadrao { get; set; }
    }
}
