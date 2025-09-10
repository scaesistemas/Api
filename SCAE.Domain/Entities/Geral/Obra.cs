using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("obra", Schema = "geral")]
    public class Obra : IEntity
    {
        public int Id { get; set; }
        public Empresa Empresa { get; set; }
        public CentroCusto CentroCusto { get; set; }
        public ContaGerencial ContaGerencial { get; set; }
        public Almoxarifado.Almoxarifado Almoxarifado { get; set; }
        [StringLength(45), Required] public string Nome { get; set; }
    }
}
