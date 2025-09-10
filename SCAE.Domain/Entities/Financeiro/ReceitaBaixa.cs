using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("receitabaixa", Schema = "financeiro")]
    public class ReceitaBaixa : IEntity
    {
        public int Id { get; set; }
        public int ParcelaId { get; set; }
        public ReceitaParcela Parcela { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [Required] public DateTime DataPagamento { get; set; }
        public DateTime? DataCriacao { get; set; }
        public decimal Multa { get; set; }
        public decimal Juros { get; set; }
        public decimal Desconto { get; set; }
        public decimal CorrecaoMonetaria { get; set; }
        public decimal Total => Valor + Juros + Multa - Desconto;
        [Required] public decimal Valor { get; set; }
        public int? ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get;  private set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; private set; }
        public bool Cancelado { get; set; }
        public bool Automatica { get; set; }
        public string CodigoIntegracao { get; set; }
        public ReceitaBaixaComprovante ReceitaBaixaComprovante { get; set; }
        public int? TransacaoId { get; set; }
        public ReceitaTransacao Transacao { get; set; }
        public int TipoOperacaoId { get; set; }
        public TipoOperacaoFinanceira TipoOperacao { get; set; }


        public ReceitaBaixa()
        {
            Automatica = false;
        } 
    }
}
