using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes
{
    [Table("contratodocumento", Schema = "clientes")]
    public class ContratoDocumento : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public string Descricao { get; set; }
    }
}
