using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro
{
    public class AnteciparDocumentoModel
    {
        public bool IsQuitacao { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteCPF { get; set; }
        public string Protocolo { get; set; }
        public string NumeroSequenciaContrato { get; set; }
        public string LoteNome { get; set; }
        public string QuadraNome { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string UsuarioNome { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataPagamento { get; set; }

        public string ContratoEmpresaNome { get; set; }
        public string CNPJContratoEmpresa { get; set; }

        public decimal ValorTotalParcela => Math.Round(Parcelas.Sum(x => x.SaldoParcela),2);
        public decimal TotalEncargos => Math.Round(Parcelas.Sum(x => x.Encargos),2);
        //public decimal TotalDescontoVencimento => Parcelas.Sum(x => x.DescontoVencimento);
        public decimal TotalDescontoAntecipacaoQuitacao => Math.Round(Parcelas.Sum(x => x.DescontoAntecipacaoQuitacao),2);
       // public decimal TotalDescontoQuitacao => Parcelas.Sum(x => x.DescontoQuitacao);
        public decimal ValorTotalPago => Math.Round(Parcelas.Sum(x => x.ValorPago),2);
        public decimal ValorQuitacao => Math.Round(ValorQuitacaoAdiantamento + ValorParcelaAtual + ValorParcelasVencidas, 2);
        public decimal ValorQuitacaoAdiantamento => CalcularQuitacaoAdiantamento();
        public decimal ValorParcelaAtual => Math.Round(Parcelas.Where(p => p.DataVencimento.Month == DataPagamento.Month && p.DataVencimento.Year == DataPagamento.Year && p.DataVencimento >= DataPagamento).ToList().OrderBy(p => p.ParcelaNumero).FirstOrDefault()?.ValorParcela ?? 0, 2);
        public decimal ValorParcelasVencidas => Math.Round(Parcelas.Where(p => p.DataVencimento < DataPagamento).ToList().Sum(p => p.ValorParcela), 2);
        public decimal ValorEntrada { get; set; }

        public decimal SaldoIntermediaria { get; set; }
        public decimal ValorFinalContrato => ValorQuitacao + ValorEntrada + TotalEncargos + SaldoIntermediaria;
        public ICollection<AnteciparParcelaModel> Parcelas { get; set; }

        public ICollection<AnteciparParcelaModel> ParcelasPagas {  get; set; }

        public AnteciparDocumentoModel()
        {
            Parcelas = new List<AnteciparParcelaModel>();
            ParcelasPagas = new List<AnteciparParcelaModel>();
        }

        private decimal CalcularQuitacaoAdiantamento()
        {
            var parcelasAVencer = Parcelas
                                    .Where(p => p.DataVencimento >= DataPagamento)
                                    .OrderBy(p => p.ParcelaNumero)
                                    .ToList();

            var parcelaAtualNumero = Parcelas
                                        .Where(p => p.DataVencimento.Month == DataPagamento.Month && p.DataVencimento.Year == DataPagamento.Year && p.DataVencimento >= DataPagamento)
                                        .OrderBy(p => p.ParcelaNumero)
                                        .FirstOrDefault()?.ParcelaNumero ?? 0;

            var parcelasAdiantadas = parcelasAVencer
                                        .Where(p => p.ParcelaNumero != parcelaAtualNumero)
                                        .ToList();

            return Math.Round(parcelasAdiantadas.FirstOrDefault()?.SaldoAmortizacaoInicial ?? 0m, 2);
        }
    }



    public class AnteciparParcelaModel
    {
        public int ParcelaNumero { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int DiasAtraso { get; set; }
        public decimal SaldoParcela { get; set; }
        public decimal Encargos { get; set; }
        //public decimal DescontoVencimento { get; set; }
        public decimal DescontoAntecipacaoQuitacao { get; set; }
        public decimal ValorPago { get; set; }

        ////   Price
        public decimal ValorParcela { get; set; }
        public decimal Amortizacao { get; set; }
        public decimal Juros { get; set; }
        public string SituacaoNome { get; set; }
        public decimal Gestao { get; set; }
        public decimal ValorMPI { get; set; }
        public decimal ValorDFI { get; set; }
        public decimal SaldoAmortizacaoInicial { get; set; }
        public decimal SaldoAmortizacaoFinal { get; set; }
        public decimal ValorParaAntecipar { get; set; }
        public string ParcelasAgrupadasNumero { get; set; }

    }
}
