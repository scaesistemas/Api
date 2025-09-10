using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Migracao.Entities
{
    [Table("fn_contascorrentes")]
    public class ContaCorrente
    {
        [Column("idConta")] public int Id { get; set; }
        public decimal JurosDia { get; set; }
        public decimal MultaMes { get; set; }
        public decimal Desconto { get; set; }
        public int DiasDesconto { get; set; }
        //public decimal DescontoContrato { get; set; }
        public decimal DescontoAntecipacao { get; set; }
        public int NaoReceberDias { get; set; }
    }
}
