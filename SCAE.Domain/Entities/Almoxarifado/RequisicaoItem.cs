using SCAE.Domain.Entities.Projeto;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Almoxarifado
{
    [Table("requisicaoitem", Schema = "almoxarifado")]
    public class RequisicaoItem : IEntity
    {
        public int Id { get; set; }
        public int RequisicaoId { get; set; }
        public Requisicao Requisicao { get; private set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; private set; }
        public int? UnidadeMedidaId { get; set; }
        public UnidadeMedida UnidadeMedida { get; private set; }
        public decimal CustoMedio { get; set; }
        public int EtapaId { get; set; }
        public Etapa Etapa { get; private  set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Total => Quantidade * Valor;
        public decimal TotalCustoMedio => Quantidade * CustoMedio;
    }
}