using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("despesabaixa", Schema = "financeiro")]
    public class DespesaBaixa : IEntity
    { 
        public int Id { get; set; }
        public int ParcelaId { get; set; }
        public DespesaParcela Parcela { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [Required] public DateTime DataPagamento { get; set; }
        public DateTime? DataCriacao { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total => Valor + Juros + Multa - Desconto;
        [Required] public decimal Valor { get; set; }
        public int? ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public DespesaBaixaComprovante Comprovante { get; set; }
        public bool Cancelado { get; set; }
        public bool Automatica { get; set; }
        public string CodigoIntegracao { get; set; }

        //Conciliacao OFX
        public bool Conciliado { get; set; }
        public string FitId { get; set; }

        public CentroCusto CentroCusto { get; set; }
        public int? CentroCustoId { get; set; }
       
        public ContaGerencial ContaGerencial { get; set; }
        public int? ContaGerencialId { get; set; }

        public DespesaBaixa()
        {
            Automatica = false;
        }
    }
}
