using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("empresagateway", Schema = "geral")]
    public class EmpresaGateway : IEntity
    {
        public int Id { get; set; }
        public int TipoGatewayId { get; set; }
        public TipoGateway TipoGateway { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public string CodigoIntegracao { get; set; }

    }
}
