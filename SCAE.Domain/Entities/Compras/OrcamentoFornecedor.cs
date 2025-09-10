using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras
{
    [Table("orcamentofornecedor", Schema = "compras")]
    public class OrcamentoFornecedor : IEntity
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public int FornecedorId { get; set; }
        public Pessoa Fornecedor { get; private set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; private set; }
        public int PrazoEntregaDias { get; set; }
        public int ValidadeDias { get; set; }
        public decimal Frete { get; set; }
        [Required] public bool Aprovado { get; set; }
        [NotMapped] public decimal Total { get; set; }
        public string Observacao { get; set; }

        public OrcamentoFornecedor()
        {
            Aprovado = false;
        }
    }
}
