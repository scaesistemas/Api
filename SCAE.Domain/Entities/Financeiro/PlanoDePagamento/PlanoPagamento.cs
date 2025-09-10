using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SCAE.Domain.Entities.Financeiro.PlanoDePagamento
{
    public class PlanoPagamento
    {
        private Encargo _encargoFinanceiro;
        public string Nome { get; set; }
        public int IntervaloReajusteId { get; set; }
        public IntervaloReajuste IntervaloReajuste { get; set; }
        public int TipoIndiceId { get; set; }
        public TipoIndice TipoIndice { get; set; }
        public int TipoAmortizacaoId { get; set; }
        public TipoAmortizacao TipoAmortizacao { get; set; }
        public int TipoMesReajusteId { get; set; }
        public TipoMesReajuste TipoMesReajuste { get; set; }
        public int TipoAnoInicioReajusteId { get; set; }
        public TipoAnoInicioReajuste TipoAnoInicioReajuste { get; set; }
        public decimal JurosTabela { get; set; }
        public decimal TaxaGestao { get; set; }
        public decimal SeguroMPI { get; set; }
        public decimal SeguroDFI { get; set; }
        public bool IsDFIFixo { get; set; }
        public int TipoValorTotalId { get; set; }
        public TipoPlanoPagamento TipoValorTotal { get; set; }
        public decimal ValorMetroQuadrado { get; set; }
        public decimal ValorUnidade { get; set; }
        public ReceitaPlanoPagamento Entrada { get; set; }
        public ReceitaPlanoPagamento Intermediaria { get; set; }
        public ReceitaPlanoPagamento Financiamento { get; set; }

        #region Operação Financeira
        public int? TipoOperacaoId { get; set; }
        public TipoOperacaoFinanceira TipoOperacao { get; set; }

        public int? TipoGatewayId { get; set; }
        public TipoGateway TipoGateway { get; set; }

        public int? ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }

        public Encargo EncargoFinanceiro {
            get
            {
                if (_encargoFinanceiro == null)
                    _encargoFinanceiro = new Encargo();

                return _encargoFinanceiro;
            }
            set
            {
                _encargoFinanceiro = value;
            }
        }


        public decimal TaxaBoleto { get; set; }
        #endregion

    }

    [Owned]
    public class ReceitaPlanoPagamento
    {
        public bool GerarFinanciamentoComIntermediaria { get; set; }
        public bool GerarFinanciamentoPosEntrada { get; set; }
        public bool IsReajustavel { get; set; }
        public int? TipoId { get; set; }
        public TipoPlanoPagamento Tipo { get; set; }
        public int? TipoIntervaloParcelaId { get; set; }
        public TipoIntervaloParcela TipoIntervaloParcela { get; set; }
        public decimal PorcentagemValorTotal { get; set; }
        public decimal Valor { get; set; }
        public List<int> PrazosDisponiveis { get; set; }
        public int Prazo { get; set; }

        public ReceitaPlanoPagamento()
        {

        }
        public ReceitaPlanoPagamento(ReceitaPlanoPagamento receitaPlano)
        {
            GerarFinanciamentoComIntermediaria = receitaPlano.GerarFinanciamentoComIntermediaria;
            GerarFinanciamentoPosEntrada = receitaPlano.GerarFinanciamentoPosEntrada;
            IsReajustavel = receitaPlano.IsReajustavel;
            TipoId = receitaPlano.TipoId;
            TipoIntervaloParcelaId = receitaPlano.TipoIntervaloParcelaId;
            PorcentagemValorTotal = receitaPlano.PorcentagemValorTotal;
            Valor = receitaPlano.Valor;
            PrazosDisponiveis = receitaPlano.PrazosDisponiveis;
            Prazo = receitaPlano.Prazo;
        }
    }


}
