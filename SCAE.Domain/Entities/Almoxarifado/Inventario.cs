using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Almoxarifado
{
    [Table("inventario", Schema = "almoxarifado")]
    public class Inventario : IEntity
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int AlmoxarifadoId { get; set; }
        public Almoxarifado Almoxarifado { get; set; }
        public DateTime? DataHoraExecucao { get; set; }
        public bool Executada { get; set; }
        public ICollection<InventarioItem> Itens { get; set; }

        public Inventario()
        {
            Data = DateTime.Now;
            Executada = false;
            Itens = new List<InventarioItem>();
        }
    }
}
