using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes.ContratoDigitalNS
{
    [Table("contratodigitaldocumento", Schema = "clientes")]
    public class ContratoDigitalDocumento : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int ContratoDigitalId { get; set; }
        public ContratoDigital ContratoDigital { get; set; }

    }
}
