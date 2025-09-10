using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Financeiro
{
    [Table("antecipacaoamortizacao", Schema = "financeiro")]
    public class AntecipacaoAmortizacao : IEntity
    {
        public int Id { get; set; }
        public DateTime DataAntecipacao { get; set; }
        public int TipoAntecipacaoId { get; set; }
        public TipoAntecipacao TipoAntecipacao { get; set;}
        public int ParcelaId { get; set; }
        public ReceitaParcela Parcela { get; set; }
        public int? PrimeiraParcelaAjustadaId { get; set; }
        //public ReceitaParcela PrimeiraParcelaAjustada { get; set; }
        public int QuantidadeParcelasAmortizadas { get; set; }
        public decimal ValorAmortizado { get; set; }
        public decimal SaldoAmortizacaoPreAntecipacao { get; set; }
        public decimal SaldoAmortizacaoPosAntecipacao => SaldoAmortizacaoPreAntecipacao - ValorAmortizado;
        public bool PagamentoEfetuado => Parcela != null && Parcela.SituacaoId == SituacaoReceitaParcela.Pago.Id;
        public ICollection<AntecipacaoAmortizacaoItem> Itens { get; set; }

        public AntecipacaoAmortizacao()
        {
            Itens = new List<AntecipacaoAmortizacaoItem>();
        }

    }
}
