using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("despesaparcela", Schema = "financeiro")]
    public class DespesaParcela : IEntity
    {
        public int Id { get; set; }
        public int DespesaId { get; set; }
        public Despesa Despesa { get; set; }
        [Required] public int Parcela { get; set; }
        public int? ComissaoParcelaId {get; set;}
        public ReceitaParcela ComissaoParcela { get; set; }
        public string ParcelaStr => $"{Parcela}/{Despesa?.QuantidadeParcela}";
        public DateTime DataVencimento { get; set; }
        [Required] public decimal Valor { get; set; }
        [StringLength(60)] public string LinhaDigitavelBoleto { get; set; }
        public int SituacaoId { get; set; }
        public virtual SituacaoDespesaParcela Situacao { get; set; }
        public string Observacao { get; set; }
        //public bool ConciliadoTotal => Baixas != null ? Baixas.Count == Baixas.Where(x => x.Conciliado).ToList().Count : false;

        public decimal Saldo => Baixas != null ? Valor - Baixas.Where(x => !x.Cancelado).Sum(baixa => baixa.Valor) : 0;
        public decimal ValorPago => Baixas != null ? Baixas.Where(x => !x.Cancelado).Sum(baixa => baixa.Total) : 0;
        // public DateTime? UltimaDataPagamento => Baixas != null && Baixas.Count > 0 && Baixas.Any(x => !x.Cancelado) ? Baixas.Where(x => !x.Cancelado).LastOrDefault().DataPagamento : null;

        public ICollection<DespesaBaixa> Baixas { get; set; }

        public DateTime? UltimaDataPagamento => Baixas != null && Baixas.Count > 0 && Baixas.Any(x => !x.Cancelado) ? Baixas.Where(x => !x.Cancelado).LastOrDefault().DataPagamento : null;
        public string UltimaFormaPagamento => Baixas != null && Baixas.Count > 0 && Baixas.Any(x => !x.Cancelado) ? Baixas.Where(x => !x.Cancelado).LastOrDefault().FormaPagamento?.Nome : null;
        public bool PagamentoLiberado => ComissaoParcela?.SituacaoId == SituacaoReceitaParcela.Pago.Id;
        public string CorretorNome => Despesa != null ? Despesa?.Fornecedor?.Nome : "";
        public DespesaParcela()
        {
            Baixas = new List<DespesaBaixa>();
            SituacaoId = SituacaoDespesaParcela.Aberto.Id;
        }
    }
}
