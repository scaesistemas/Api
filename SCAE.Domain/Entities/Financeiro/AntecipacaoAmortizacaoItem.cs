using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("antecipacaoamortizacaoitem", Schema = "financeiro")]
    public class AntecipacaoAmortizacaoItem : IEntity
    {
        public int Id { get ; set ; }
        public int AntecipacaoAmortizacaoId { get; set ; }
        public AntecipacaoAmortizacao AntecipacaoAmortizacao { get; set ; }
        public int ParcelaId { get; set; }
        public ReceitaParcela Parcela { get; set;}
        public DadosParcelaPreAmortizacao DadosParcelaPreAmortizacao { get; set; }
        public decimal ValorParcelaPosAmortizacao { get; set; }
        public decimal ValorReduzidoParcela => DadosParcelaPreAmortizacao.ValorParcela - ValorParcelaPosAmortizacao;

        public AntecipacaoAmortizacaoItem()
        {
            DadosParcelaPreAmortizacao = new DadosParcelaPreAmortizacao();
        }


    }

    [Owned]
    public class DadosParcelaPreAmortizacao
    {
        public decimal ValorParcela { get; set; }
        public decimal Amortizacao  { get; set; }
        public decimal Juros { get; set; }
        public decimal SaldoAmortizacaoInicioPeriodo { get; set; }
        public decimal SaldoAmortizacaoFimPeriodo { get; set; }
        public decimal ValorMPI { get; set; }
        public decimal ValorDFI { get; set; }
    }
}
