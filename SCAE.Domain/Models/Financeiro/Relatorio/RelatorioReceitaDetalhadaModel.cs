using System;
using System.Collections.Generic;
using System.Linq;

namespace SCAE.Domain.Models.Financeiro.Relatorio
{
    public class RelatorioReceitaDetalhadaModel
    {
        public RelatorioReceitaDetalhadaModel()
        {
            Parcelas = new List<ParcelaReceitaDetalhadaModel>();
        }

        public List<ParcelaReceitaDetalhadaModel> Parcelas { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPagoTotal { get; set; }
        public decimal ValorAPagarTotal => Math.Max(0, ValorTotal - ValorPagoTotal);
        // public decimal ValorAPagarTotal => ValorTotal - ValorPagoTotal;
        public decimal JurosTotal { get; set; }
        public decimal MultaTotal { get; set; } 
        public decimal EncargosTotal => JurosTotal + MultaTotal;
        public decimal DescontoTotal { get; set; }
        public int QuantidadeParcelasTotal { get; set; }
        public decimal TotalTaxaBoleto => Parcelas?.Sum(x => x.ValorTaxaBoletoParcela) ?? 0;
        public decimal TotalTaxaAdicional => Parcelas?.Sum(x => x.ValorTaxaAdicionalParcela) ?? 0;
        public decimal TotalTaxas => TotalTaxaBoleto + TotalTaxaAdicional;
        public int QuantidadeParcelasPagas => Parcelas?.Count(x => x.SituacaoParcela == "Pago") ?? 0;
        public int QuantidadeParcelasAbertas => Parcelas?.Count(x => x.SituacaoParcela == "Aberto") ?? 0;
        public int QuantidadeParcelasPagasParcialmente => Parcelas?.Count(x => x.SituacaoParcela == "Pago Parcialmente") ?? 0;
        public int QuantidadeParcelasPagasSemAgrupador => Parcelas?.Count(x => (x.SituacaoParcela == "Pago" && x.IsAgrupador == false)) ?? 0;
        public int QuantidadeTotalParcelasPagasSemAgrupador { get; set; }

        public decimal EncargosPagos { get; set; }
        public decimal EncargosApagar {  get; set; }
        public decimal ValorPagoParcelaSemJurosDesconto { get; set; }

        public int ParcelasEmAbertoParcial {  get; set; }

        public decimal ValorTotalEmAbertoSemJuros { get; set; }
    }

    public class ParcelaReceitaDetalhadaModel
    {
        public int ParcelaId { get; set; }
        public string NumeroSequenciaContrato { get; set; }
        public int NumeroContrato { get; set; }
        public int SequenciaContrato { get; set; }
        public int? SituacaoContratoId { get; set; }
        public int ParcelaNumero { get; set; }
        public int TotalParcelas { get; set; }
        public string ClienteNome { get; set; }
        public string CorretorNome { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string UnidadeQuadra { get; set; }
        public string UnidadeLote { get; set; }
        public string TipoReceita { get; set; }
        public int TipoReceitaId { get; set; }
        public DateTime VencimentoParcela { get; set; }
        public string DataPagamentoParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public string SituacaoParcela { get; set; }
        public string FormaPagamentoParcela { get; set; }
        public bool BaixaAutomatica { get; set; }
        public decimal JurosParcelaBaixa { get; set; }
        public decimal MultaParcelaBaixa { get; set; }
        public decimal DescontosParcelaBaixa { get; set; }
        public decimal ValorPagoParcela { get; set; }
        public decimal ValorPagoParcelaSemJurosDesconto { get; set; }
        public decimal ValorTotalPagoParcela { get; set; }
        //adicionar valor total pago do contrato Financiamento + Intermediaria
        //adicionar valor total pago do contrato Entrada
        //adicionar valor total pago do contrato Servico
        //adicionar valor total pago do contrato Aditamento
        public string UsuarioBaixa { get; set; }
        public string ParcelasAgrupadas { get; set; }
        public string EmpresaNome { get; set; }
        public string TipoAditamentoNome { get; set; }
        public bool Agrupada { get; set; }
        public string Observacao { get; set; }
        public DateTime VencimentoOriginalParcela { get; set; }
        public string TipoServicoNome { get; set; }
        public string NumeroDocumento { get; set; }
        public string ClienteCPF { get; set; }
        public string TipoGatewayNome { get; set; }
        public decimal ValorTaxaBoletoParcela { get; set; }
        public decimal ValorTaxaAdicionalParcela { get; set; }
        public string NomeTaxaAdicionalParcela { get; set; }
        public decimal TaxasGerais => ValorTaxaBoletoParcela + ValorTaxaAdicionalParcela;
        public decimal ValorParcelaTaxas => ValorParcela + TaxasGerais;

        public bool IsAgrupador { get; set; }

        public decimal EncargosPagos { get; set; }
        public decimal EncargosApagar { get; set; }


    }
}
