using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Financeiro.Relatorio
{
    public class RelatorioPriceSacModel
    {
        public RelatorioPriceSacModel()
        {
            Parcelas = new List<ParcelaPriceSacModel>();
        }

        public List<ParcelaPriceSacModel> Parcelas { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPagoTotal { get; set; }
        public decimal JurosTotal { get; set; }
        public decimal MultaTotal { get; set; }
        public decimal EncargosTotal => JurosTotal + MultaTotal;
        public decimal DescontoTotal { get; set; }
        public int QuantidadeParcelasTotal { get; set; }

    }

    public class ParcelaPriceSacModel
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
        public DateTime DataPagamentoParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public string SituacaoParcela { get; set; }
        public string FormaPagamentoParcela { get; set; }
        //public bool BaixaAutomatica { get; set; }
        public decimal JurosParcelaBaixa { get; set; }
        public decimal MultaParcelaBaixa { get; set; }
        public decimal DescontosParcelaBaixa { get; set; }
        public decimal ValorPagoParcela { get; set; }
        public decimal ValorTotalPagoParcela { get; set; }
        public string UsuarioBaixa { get; set; }
        public string ParcelasAgrupadas { get; set; }
        public string EmpresaNome { get; set; }
        //  public string TipoAditamentoNome { get; set; }
        public bool Agrupada { get; set; }

        //PRICE-SAC

        public decimal Amortizacao { get; set; }
        public decimal CorrecaoMonetaria { get; set; }
        public decimal Juros { get; set; }
        public decimal MPI { get; set; }
        public decimal DFI { get; set; }
        public decimal Gestao { get; set; }
        public decimal ValorSemAdicionais { get; set; }

    }
}
