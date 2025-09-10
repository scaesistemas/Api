using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Migracao.Entities
{
    [Table("cl_contratos_observacoes")]
    public class ContratoObservacao
    {
        [Column("idObservacao")] public int Id { get; set; }
        //public Contrato Contrato { get; set; }
        [Column("idContrato")] public int ContratoId { get; set; }
        public int Sequencia { get; set; }
        [Column("Observacao")] public string Texto { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
