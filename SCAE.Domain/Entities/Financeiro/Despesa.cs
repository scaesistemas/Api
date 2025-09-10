using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Compras;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Projeto;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("despesa", Schema = "financeiro")]
    public class Despesa : IEntity 
    { 
        public int Id { get; set; }
        public int? CodigoOrigem { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int? EmpreendimentoId { get; set; }
        public Empreendimento.Empreendimento Empreendimento { get; set; }
        public int? ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public int TipoId { get; set; }
        public TipoDespesa Tipo { get; set; }
        public int OrigemId { get; set; }
        public OrigemDespesa Origem { get; set; }
        public int FornecedorId { get; set; }
        public Pessoa Fornecedor { get; set; }
        [Required] public DateTime DataEmissao { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime? DataCriacao { get; set; }
        public TimeSpan? HoraCriacao { get; set; }
        [Required] public decimal Valor { get; set; }
        public int TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        [StringLength(35)] public string NumeroDocumento { get; set; }
        [StringLength(44)] public string ChaveDfe { get; set; }
        public string Observacao { get; set; }
        public decimal Saldo => Parcelas != null ? Parcelas.Where(parcela => parcela.SituacaoId != SituacaoDespesaParcela.Cancelado.Id).Sum(parcela => parcela.Saldo) : 0;
        public decimal TotalPagoParcelas => Parcelas?.Sum(x => x.ValorPago) ?? 0;
        public decimal SaldoPreAditamento { get; set; }
        public int QuantidadeParcela => Parcelas?.Count() ?? 0; 
        public List<DespesaParcela> Parcelas { get; set; }
        public ICollection<DespesaClassificacao> Classificacoes { get; set; }
        public ICollection<DespesaDocumento> Documentos { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public bool IsMultiplosPedidos { get; set; }

        public decimal ValorParcelaAtual => Parcelas.Count > 0 && Parcelas != null ? Parcelas.Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)).OrderBy(t => Math.Abs((t.DataVencimento - DateTime.Now).Ticks)).FirstOrDefault()?.Valor ?? 0 : 0;

        public decimal ValorDespesaAtual => Parcelas != null ? Parcelas.Where(parcela => parcela.SituacaoId != SituacaoDespesaParcela.Cancelado.Id).Sum(parcela => parcela.Valor) : 0;

        public List<DespesaObservacao> Observacoes { get; set; }

        public Despesa()
        {
            Parcelas = new List<DespesaParcela>();
            Classificacoes = new List<DespesaClassificacao>();
            Documentos = new List<DespesaDocumento>();
            Pedidos = new List<Pedido>();
            Observacoes = new List<DespesaObservacao>();
            OrigemId = OrigemDespesa.Financeiro.Id;
            DataCriacao = DateTime.Now;
            HoraCriacao = DateTime.Now.TimeOfDay;
        }
    }
}
