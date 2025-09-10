using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace SCAE.Domain.Entities.Financeiro
{
    [Table("tipotransacao", Schema = "financeiro")]
    public class TipoStatusTransacao : IEntity
    {

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoStatusTransacao Criacao => new TipoStatusTransacao(1, "Criação de parcela");
        [NotMapped] public static TipoStatusTransacao Edicao => new TipoStatusTransacao(2, "Edição de parcela");
        [NotMapped] public static TipoStatusTransacao ReajusteIndice => new TipoStatusTransacao(3, "Reajuste de índice");
        [NotMapped] public static TipoStatusTransacao Baixa => new TipoStatusTransacao(4, "Baixa");
        [NotMapped] public static TipoStatusTransacao BaixaWebhook => new TipoStatusTransacao(5, "Baixa Webhook");
        [NotMapped] public static TipoStatusTransacao BaixaWorker => new TipoStatusTransacao(6, "Baixa Worker");
        [NotMapped] public static TipoStatusTransacao BaixaCancelada => new TipoStatusTransacao(7, "Baixa cancelada");
        [NotMapped] public static TipoStatusTransacao BaixaImportacao => new TipoStatusTransacao(8, "Baixa importada");
        [NotMapped] public static TipoStatusTransacao EmissaoBoleto => new TipoStatusTransacao(9, "Emissão de boleto");
        [NotMapped] public static TipoStatusTransacao BoletoCanceladoNormal => new TipoStatusTransacao(10, "Boleto cancelado normal");
        [NotMapped] public static TipoStatusTransacao BoletoCanceladoForcado => new TipoStatusTransacao(11, "Boleto cancelado forçado");
        [NotMapped] public static TipoStatusTransacao Amortizacao => new TipoStatusTransacao(12, "Amortização");



        public TipoStatusTransacao(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoStatusTransacao[] ObterDados()
        {
            return new TipoStatusTransacao[]
            {
                Criacao,
                Edicao,
                ReajusteIndice,
                Baixa,
                BaixaWebhook,
                BaixaWorker,
                BaixaCancelada,
                BaixaImportacao,
                EmissaoBoleto,
                BoletoCanceladoNormal,
                BoletoCanceladoForcado,
                Amortizacao
            };
        }

        public static TipoStatusTransacao Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }

        public static TipoStatusTransacao ObterPorNome(string tipo)
        {
            if (string.IsNullOrEmpty(tipo))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == tipo.ToUpper());
        }
    }

}
