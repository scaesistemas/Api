using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("reguacobranca", Schema = "financeiro")]
    public class ReguaCobranca : IEntity
    {
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
       public List<ReguaCobrancaEtapa> Etapas { get; set; }

    }
}
