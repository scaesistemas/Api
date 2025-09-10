using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Migracao.Entities
{
    [Table("cl_quadras")]
    public class Quadra
    {
        [Column("idQuadra")] public int Id { get; set; }
        [Column("idLoteamento")] public int LoteamentoId { get; set; }
        [Column("CodigoQuadra")] public string Codigo { get; set; }
        public ICollection<Lote> Lotes { get; set; }
    }
}