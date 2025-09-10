using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro.Relatorio
{
    public class RelatorioDespesaDetalhadaModel
    {
        public RelatorioDespesaDetalhadaModel()
        {
            Parcelas = new List<ParcelaDespesaDetalhadaModel>();
        }

        public List<ParcelaDespesaDetalhadaModel> Parcelas { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPagoTotal { get; set; }
        public decimal ValorAPagarTotal => ValorTotal - ValorPagoTotal;
        public decimal JurosTotal { get; set; }
        public decimal MultaTotal { get; set; }
        public decimal EncargosTotal => JurosTotal + MultaTotal;
        public decimal DescontoTotal { get; set; }
        public int QuantidadeParcelasTotal { get; set; }
        public int QuantidadeParcelasPagas => Parcelas?.Count(x => x.SituacaoParcela == "Pago") ?? 0;
        public int QuantidadeParcelasAbertas => Parcelas?.Count(x => x.SituacaoParcela == "Aberto") ?? 0;

    }

    public class ParcelaDespesaDetalhadaModel
    {
        public int ParcelaId { get; set; }
        public string NumeroSequenciaContrato { get; set; }
        public int ParcelaNumero { get; set; }
        public int TotalParcelas { get; set; }
        public string FornecedorNome { get; set; }
        public string FornecedorCNPJ { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string UnidadeQuadra { get; set; }
        public string UnidadeLote { get; set; }
        public string TipoDespesa { get; set; }
        public string VencimentoParcela { get; set; }
        public string DataPagamentoParcela { get; set; }
        public string DespesaDataEmissao { get; set; }
        public decimal ValorParcela { get; set; }
        public string SituacaoParcela { get; set; }
        public string FormaPagamentoParcela { get; set; }
        public decimal JurosParcelaBaixa { get; set; }
        public decimal MultaParcelaBaixa { get; set; }
        public decimal DescontosParcelaBaixa { get; set; }
        public decimal ValorPagoParcela { get; set; }
        public decimal ValorTotalPagoParcela { get; set; }
        public string UsuarioBaixa { get; set; }
        public string EmpresaNome { get; set; }
        public string TipoAditamentoNome { get; set; }
        public string CentroCustoNome { get; set; }
        public string ContaGerencialNome { get; set; }
        public int DespesaId { get; set; }
        public string NumeroDocumento { get; set; }
        public string ChaveDeAcesso { get; set; }
        public string DespesaObservacao { get; set; }
        public string FornecedorCPF { get; set; } 
        public string ContaCorrenteNome { get; set; }
        public string ParcelaObservacao { get; set; }

    }


    public class DespesaRateadaClassificacaoModel {


        public string ResumoContabil { get; set; }

        public decimal Valor { get; set; }

        public decimal Percentual { get; set; }
    
    }

}

