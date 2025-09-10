using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras
{
    [Table("orcamentoitem_fornecedor", Schema = "compras")]
    public class OrcamentoItemFornecedor : IEntity
    {
        public int Id { get; set; }
        public int OrcamentoItemId { get; set; }
        public int FornecedorId { get; set; }
        public Pessoa Fornecedor { get; private set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
