using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Almoxarifado
{
    [Table("inventarioitem", Schema = "almoxarifado")]
    public class InventarioItem : IEntity
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public Inventario Inventario { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
    }
}
