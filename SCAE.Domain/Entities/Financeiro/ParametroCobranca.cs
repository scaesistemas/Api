using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("parametrocobranca", Schema = "financeiro")]
    public class ParametroCobranca : IEntity
    {
        public int Id { get; set; }
        public int ParametroId { get; set; }
        public Parametro Parametro { get; set; }
        public int Dias { get; set; }
        public bool PosVencimento { get; set; }
        public int LayoutCobrancaId { get; set; }
        public bool EnviarSms { get; set; }
        public LayoutCobranca LayoutCobranca { get; set; }
        public bool EnviarWhatsapp { get; set; }
    }
}
