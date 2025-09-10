using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("TipoContratoFornecedor", Schema = "projeto")]
    public class TipoContratoFornecedor : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped]public static TipoContratoFornecedor Produto => new TipoContratoFornecedor(1, "Produto");
        [NotMapped] public static TipoContratoFornecedor ServicoProduto => new TipoContratoFornecedor(2,"Serviço e Produto");
        [NotMapped] public static TipoContratoFornecedor Servico => new TipoContratoFornecedor(3, "Serviço");

        public TipoContratoFornecedor(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoContratoFornecedor[] ObterDados()
        {
            return new TipoContratoFornecedor[]
            {
                Produto,
                ServicoProduto,
                Servico
            };
        }

    }
}
