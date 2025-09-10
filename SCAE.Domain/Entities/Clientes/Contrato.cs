using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Domain.Models.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SCAE.Domain.Entities.Clientes
{ 
    [Table("contrato", Schema = "clientes")]
    public class Contrato : IEntity 
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int Numero { get; set; }
        public int Sequencia { get; set; }
        public int? UnidadePrincipalId { get; set; }
        public Unidade UnidadePrincipal { get; set; }
        public ICollection<ContratoUnidadeAdicional> UnidadesAdicionais { get; set; }
        public int TipoId { get; set; }
        public TipoContrato Tipo { get; set; }
        public int TipoProdutoId { get; set; }
        public TipoProdutoContrato TipoProduto { get; set; }
        public TipoAditamentoContrato TipoAditamento { get; set; }
        public int? TipoAditamentoId { get; set; }
        public ICollection<ContratoCliente> Clientes { get; set; }
        public List<ContratoCorretor> Corretores { get; set; }
        public decimal PercentualAdiministradora { get; set; }
        public DateTime Data { get; set; }
        public DateTime? DataCriacao { get; set; } 
        public string Descricao { get; set; }
        public int TipoIndiceId { get; set; }
        public TipoIndice TipoIndice { get; set; }
        public int IntervaloReajusteId { get; set; }
        public IntervaloReajuste IntervaloReajuste { get; set; }
        public int TipoAmortizacaoId { get; set; }
        public TipoAmortizacao TipoAmortizacao { get; set; }
        public decimal JurosAmortizacao { get; set; }
        public decimal Valor { get; set; }

        public decimal ValorComissaoCorretor { get; set; }
        public Encargo EncargoFinanceiro { get; set; }
        public int QuantidadeParcela { get; set; }
        public bool Renovavel { get; set; }
        public int PeriodicidadeReajuste { get; set; }
        public int PeriodicidadeRenovacao { get; set; }
        public int MesReajuste { get; set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento.Empreendimento Empreendimento { get; set; }
        public int PrazoContratual { get; set; }
        public DateTime? PrimeiroVencimento { get; set; }
        public DateTime DataVencimentoOriginal { get; set; }
        public short MelhorDia { get; set; }
        public string NumeroProcessoJudicial { get; set; }
        public int? TipoProcessoJudicialId { get; set; }
        public TipoProcessoJudicial TipoProcessoJudicial { get; set; }
        public List<ContratoObservacao> Observacoes { get; set; }
        public virtual SituacaoContrato Situacao { get; set; }
        public int SituacaoId { get; set; }

        public ICollection<HistoricoSituacaoContrato> HistoricoSituacoes { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
        public ICollection<Receita> Receitas { get; set; }
        public ICollection<ContratoVistoria> Vistorias { get; set; }
        public ICollection<ContratoDigitalNS.ContratoDigital> ContratosDigitais { get; set; }
        public List<ContratoDocumento> Documentos { get; set; }
        public int Prazo { get; set; }
        public string Responsavel { get; set; }
        public int? CodigoOrigem { get; set; }
        public string NumeroSequencia => $"{Numero}-{Sequencia}";
        public int? ContratoAnteriorAditadoId { get; set; }
        public Contrato ContratoAnteriorAditado { get; set; }
        public int AnoPrimeiroReajuste { get; set; }
        public int? TipoGatewayId { get; set; }
        public TipoGateway TipoGateway { get; set; }
        public int? ContaCorrenteId { get; set; } 
        public ContaCorrente ContaCorrente { get; set; }
        public int TipoOperacaoId { get; set; }
        public TipoOperacaoFinanceira TipoOperacao { get; set; }
        public Reserva Reserva { get; set; }


        //Detalhes de todas as receitas do contrato
        public decimal SaldoGeral => Receitas != null ? Receitas.Sum(x => x.Saldo) : 0;
        public decimal ValorTotalContrato => Receitas?.Where(x => x.SaldoAmortizacaoInicial <= 0)?.Sum(x => x.Valor) + Receitas?.Where(x => x.SaldoAmortizacao > 0)?.Sum(x => x.SaldoAmortizacaoInicial) ?? 0;
        public decimal TotalPagoGeral => Receitas?.Sum(x => x.TotalPagoParcelas) ?? 0;
        public int QuantidadeParcelasPagasGeral => Receitas?.Sum(x => x.QuantidadeParcelasPagas) ?? 0;
        public int QuantidadeParcelasPagasFinanciamento => Receitas?.Sum(x => x.QuantidadeParcelaPagasFinanciamento) ?? 0;
        public int QuantidadeParcelasAPagarFinanciamento => Receitas?.Sum(x => x.QuantidadeParcelaFinanciamento) - QuantidadeParcelasPagasFinanciamento ?? 0;

        public int QuantidadeParcelasAPagar => Receitas?.Sum(receita => receita.QuantidadeParcelaRestante) ?? 0;

        //  public int QuantidadeParcelasAPagar => Receitas?.Sum(x => x.QuantidadeParcela) - QuantidadeParcelasPagasGeral  ?? 0;
        public string PrimeiroCliente => Clientes?.FirstOrDefault()?.Cliente?.Nome ?? "";
        public string PrimeiroCorretor => Corretores.FirstOrDefault()?.Corretor?.Nome ?? "";


        public Contrato()
        {
            EncargoFinanceiro = new Encargo();
            Receitas = new List<Receita>();
            Clientes = new List<ContratoCliente>();
            Corretores = new List<ContratoCorretor>();
            Observacoes = new List<ContratoObservacao>();
            Documentos = new List<ContratoDocumento>();
            SituacaoId = SituacaoContrato.EmAndamento.Id;
            HistoricoSituacoes = new List<HistoricoSituacaoContrato>();
            ContratosDigitais = new List<ContratoDigital>();
            UnidadesAdicionais = new List<ContratoUnidadeAdicional>();
        }

    }

    [Table("contratocorretor", Schema = "clientes")]
    public class ContratoCorretor
    { 
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public int CorretorId { get; set; }
        public Pessoa Corretor { get; set; }
        public decimal Percentual { get; set; }
        public decimal ValorFixo { get; set; }
        public bool isPercentual { get; set; }
        public int QuantidadeParcela { get; set; }
        [NotMapped] public List<LigacaoParcelaDespesa> LigacaoParcelas { get; set; }

    } 

    [Table("contratocliente", Schema = "clientes")]
    public class ContratoCliente : IEntity
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public int ClienteId { get; set; }
        public Pessoa Cliente { get; set; }
    }


    [Table("contratounidadeadicional", Schema = "clientes")]
    public class ContratoUnidadeAdicional : IEntity
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
    }

}
