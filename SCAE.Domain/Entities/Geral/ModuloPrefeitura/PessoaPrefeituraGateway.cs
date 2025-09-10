using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral.ModuloPrefeitura
{
    [Table("pessoaprefeituragateway", Schema = "geral")]
    public class PessoaPrefeituraGateway : IEntity
    {
        public int Id { get; set; }
        public int TipoGatewayId { get; set; }
        public TipoGateway TipoGateway { get; set; }
        public int PessoaPrefeituraId { get; set; }
        public PessoaPrefeitura PessoaPrefeitura { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public string CodigoIntegracao { get; set; }
    }
}
