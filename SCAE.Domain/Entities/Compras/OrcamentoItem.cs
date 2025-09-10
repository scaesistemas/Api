using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras
{
    [Table("orcamentoitem", Schema = "compras")]
    public class OrcamentoItem : IEntity
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public Orcamento Orcamento { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public ICollection<OrcamentoItemFornecedor> ItemFornecedores { get; set; }

        public OrcamentoItem()
        {
            ItemFornecedores = new List<OrcamentoItemFornecedor>();
        }
    }
}
