using System;
using System.Collections.Generic;
using System.Linq;
namespace SCAE.Domain.Models.Clientes;


public class RelatorioGerencialCarteira
{
    public List<RelatorioGerencialCarteiraItensModel> itens { get; set; }

    public decimal TotaisPago => itens?.Sum(item => item.ValorTotalPago) ?? 0;

    public decimal TotaisAberto => itens?.Sum(item => item.ValorTotalAberto) ?? 0;

    public int QtdeContrato => itens?.Count() ?? 0;


    public decimal TotalGeralVenda => itens?.Sum(item => item.ValorContrato) ?? 0;

    public decimal TotalGeralAReceber => itens?.Sum(item => item.SaldoQuitacao) ?? 0;

    public decimal TotalGeralEmAtraso0a30 => itens?.Sum(item => item.TotalEmAtraso0a30) ?? 0;

    public decimal TotalGeralEmAtraso31a90 => itens?.Sum(item => item.TotalEmAtraso31a90) ?? 0;

    public decimal TotalGeralEmAtrasoAcima90 => itens?.Sum(item => item.TotalEmAtrasoAcima90) ?? 0;


}

public class RelatorioGerencialCarteiraItensModel
{
    public string EmpreendimentoNome { get; set; }
    public string GrupoNome { get; set; }
    public string UnidadeNome { get; set; }

    public decimal AreaTotalUnidade { get; set; }

    public string ClienteNome { get; set; }
    public string ClienteCPF { get; set; }

    public string NumeroSequenciaContrato { get; set; }
    public string SituacaoContrato { get; set; }
    public DateTime DataContrato { get; set; }
    public decimal ValorTotalPago { get; set; }
    public decimal ValorTotalAberto { get; set; }
    public decimal ValorFinanciamento { get; set; }
    public decimal ValorEntrada { get; set; }
    public decimal ValorServiço { get; set; }
    // public decimal ValorFinanciamentoComIntermediaria { get; set; }
    public decimal ValorIntermediaria { get; set; }

    public decimal ValorContrato { get; set; }


    public string TipoAmortizacaoNome { get; set; }
    public decimal TotalParcelas { get; set; }
    public decimal TotalParcelasRecebida { get; set; }
    public decimal TotalParcelasAReceber { get; set; }
    public decimal TotalParcelasEmAtraso { get; set; }

    public decimal TotalEmAtraso0a30 { get; set; }
    public decimal TotalEmAtraso31a90 { get; set; }
    public decimal TotalEmAtrasoAcima90 { get; set; }

    public DateTime? DataFinalContrato { get; set; }

    public decimal Juros { get; set; }

    public string IndiceNome { get; set; }


    // novos atributos que o Pedro pediu
    public decimal ValorTabela { get; set; } //valor da unidade (que vem do plano de pagamento)
    public decimal ValorDesconto { get; set; } // valor pego do crm
    public decimal ValorFinal { get; set; } // soma das parcelas do Financiamento + Intermediárias]


    public decimal SaldoQuitacao { get; set; }

    public int ReceitaIdFinanciamento { get; set; }

    public int TipoAmortizacaoId { get; set; }


    public decimal SaldoFinanciamento { get; set; }

    public decimal SaldoIntermediaria { get; set; }
    public decimal SaldoEntrada { get; set; }


}
