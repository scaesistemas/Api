using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Geral
{
    [Table("pessoagateway", Schema = "geral")]
    public class PessoaGateway : IEntity
    {
        public int Id { get; set; }
        public int TipoGatewayId { get; set; }
        public TipoGateway TipoGateway { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public string CodigoIntegracao { get; set; }
        public string ClientId { get; set; }
        public string ClientHash { get; set; }
    }
}
