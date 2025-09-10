using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("orcadoitem", Schema = "projeto")]
    public class OrcadoItem : IEntity
    {
        public int Id { get; set; }
        public int OrcadoId { get; set; }
        public Orcado Orcado { get; set; }
        public int EtapaId { get; set; }
        public Etapa Etapa { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Total => Quantidade * ValorUnitario;
    }
}
