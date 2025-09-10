using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes
{
    [Table("contratovistoria", Schema = "clientes")]
    public class ContratoVistoria : IEntity
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public string DescricaoReparo { get; set; }
        public decimal ValorReparo { get; set; }
        public ICollection<ContratoVistoriaFoto> Fotos { get; set; }
        public string Vistoriador { get; set; }
    }
}
