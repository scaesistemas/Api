using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Financeiro
{
    [Table("contacorrentegateway", Schema = "financeiro")]
    public class ContaCorrenteGateway : IEntity
    {
        public int Id { get; set; }
        public int TipoGatewayId { get; set; }
        public TipoGateway TipoGateway { get; set; }
        public int ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public string CodigoIntegracao { get; set; }

    }
}
