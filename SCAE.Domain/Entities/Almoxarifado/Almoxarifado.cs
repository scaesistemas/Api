using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Almoxarifado
{
    [Table("almoxarifado", Schema = "almoxarifado")]
    public class Almoxarifado : IEntity
    {
        public int Id { get; set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento.Empreendimento Empreendimento { get; set; }
        [StringLength(45), Required] public string Nome { get; set; }
        public ICollection<AlmoxarifadoItem> Itens { get; set; }

        public Almoxarifado()
        {
            Itens = new List<AlmoxarifadoItem>();
        }
    }
}
