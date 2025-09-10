using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes
{
    [Table("contratovistoriafoto", Schema = "clientes")]
    public class ContratoVistoriaFoto : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int ContratoVistoriaId { get; set; }
        public ContratoVistoria ContratoVistoria { get; set; }
        public string Descricao { get; set; }
    }
}
