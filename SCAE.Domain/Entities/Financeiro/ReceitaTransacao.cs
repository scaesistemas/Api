using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("receitatransacao", Schema = "financeiro")]
    public class ReceitaTransacao : IEntity
    {
        public int Id { get; set; }
        public int ParcelaId { get; set; }
        public ReceitaParcela Parcela { get; set; }
        public string BancoNumero { get; set; }
        public int? TipoGatewayId { get; set; }
        public TipoGateway TipoGateway { get; set; }
        public int TipoOperacaoId { get; set; }
        public TipoOperacaoFinanceira TipoOperacao { get; set; }
        public string CodigoIntegracao { get; set; }
        public string UrlBoleto { get; set; }
        [StringLength(60)] public string LinhaDigitavelBoleto { get; set; }
        public string QrCode { get; set; }
        public DateTime? DataRemessa { get; set; }
        public int? UsuarioBoletoGeradoId { get; set; }
        public Usuario UsuarioBoletoGerado { get; set; }
        public DateTime DataEmissao { get; set; }
        public int SituacaoId { get; set; }
        public SituacaoReceitaParcela Situacao { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set;}
        public int? ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public ICollection<ReceitaBaixa> Baixas { get; set;}
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Desconto { get; set; }
        public int? UsuarioTransacaoId { get; set; }
        public Usuario UsuarioTransacao { get; set; }
        public int? RemessaId { get; set; }
        public Remessa Remessa { get; set; }
        public Encargo EncargoFinanceiro { get; set; }
        //public ValoresAdicionais ValoresAdicionais { get; set; }
        public decimal TaxaBoleto { get; set; }
        [StringLength(20)] public string NossoNumero { get; set; }

        public bool CriadoPorUmReajusteIndice { get; set; }
        public string Descricao { get; set; }
        public string ReferenceIdBoleto { get; set; }
        public int? TipoStatusTransacaoId {get; set;}
        public TipoStatusTransacao TipoStatusTransacao {get; set;}
        public DateTime? DataCancelamento {get;set;}
        public string CodigoBarra { get; set; }

        public ReceitaTransacao()
        {
            Baixas = new List<ReceitaBaixa>();
            EncargoFinanceiro = new Encargo();
            //ValoresAdicionais = new ValoresAdicionais();
        }
    }
}
