using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Clientes
{
    [Table("tipoaditamento", Schema = "clientes")]
    public class TipoAditamentoContrato : IEntity
    {

            [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }
            [StringLength(60), Required] public string Nome { get; set; }
            [NotMapped] public static TipoAditamentoContrato AcordoPossuidor => new TipoAditamentoContrato(1, "Acordo com possuidor");
            [NotMapped] public static TipoAditamentoContrato AcordoTranferencia => new TipoAditamentoContrato(2, "Acordo com transferência");
            [NotMapped] public static TipoAditamentoContrato AcordoJudicial => new TipoAditamentoContrato(3, "Acordo judicial");
            [NotMapped] public static TipoAditamentoContrato AcordoMediacao => new TipoAditamentoContrato(4, "Acordo mediação");
            [NotMapped] public static TipoAditamentoContrato AcordoSimples => new TipoAditamentoContrato(5, "Acordo simples");
            [NotMapped] public static TipoAditamentoContrato MediacaoTransferencia => new TipoAditamentoContrato(6, "Mediação com transferência");
            [NotMapped] public static TipoAditamentoContrato Transferencia => new TipoAditamentoContrato(7, "Transferência");
            [NotMapped] public static TipoAditamentoContrato Ajuste => new TipoAditamentoContrato(8, "Ajuste");

        public TipoAditamentoContrato(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

         public static TipoAditamentoContrato[] ObterDados()
         {
             return new TipoAditamentoContrato[]
             {
                 AcordoPossuidor,
                 AcordoTranferencia,
                 AcordoJudicial,
                 AcordoMediacao,
                 AcordoSimples,
                 MediacaoTransferencia,
                 Transferencia,
                 Ajuste,
             };
         }
        public static TipoAditamentoContrato ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }

    }
}
