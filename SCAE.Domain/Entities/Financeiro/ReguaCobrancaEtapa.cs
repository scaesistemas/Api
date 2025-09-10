using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Financeiro
{
    [Table("reguacobrancaetapa", Schema = "financeiro")]
    public class ReguaCobrancaEtapa: IEntity
    {
        public int Id { get; set; }
        //public ReguaCobranca ReguaCobranca { get; set; }
        public int ReguaCobrancaId { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
               
        [Required, Range(1, int.MaxValue)] public int MinimoDiasVencido { get; set; }
        public int MaximoDiasVencido { get; set; }


    }
}
