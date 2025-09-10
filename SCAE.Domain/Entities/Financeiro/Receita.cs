using Microsoft.IdentityModel.Tokens;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("receita", Schema = "financeiro")]
    public class Receita : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int? EmpreendimentoId { get; set; } 
        public Empreendimento.Empreendimento Empreendimento { get; set; }
        public int TipoId { get; set; }
        public TipoReceita Tipo { get; set; }
        public int ClienteId { get; set; }
        public Pessoa Cliente { get; set; }
        public int? ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        [Required] public DateTime DataEmissao { get; set; }
        [Required] public decimal Valor { get; set; }
        public int TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        [StringLength(20)] public string NumeroDocumento { get; set; }
        public string Observacao { get; set; }
        public decimal SaldoPreAditamento { get; set; }
        public bool GerarBoletoAutomatico { get; set; }
        public bool RealizarCobrancaAutomatica { get; set; }
        public int? TipoGatewayId { get; set; }
        public TipoGateway TipoGateway { get; set; }
        public bool IsReajustavel { get; set; }
        public int? ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public int TipoOperacaoId { get; set; }
        public TipoOperacaoFinanceira TipoOperacao { get; set; }

        public bool IsReceitaAgua { get; set; }


        public ICollection<ReceitaParcela> Parcelas { get; set; }
        public ICollection<ReceitaClassificacao> Classificacoes { get; set; }
        public ICollection<ReceitaDocumento> Documentos { get; set; }

        public decimal Saldo => Parcelas != null ? Parcelas.Where(parcela => (parcela.SituacaoId == SituacaoReceitaParcela.Aberto.Id || parcela.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && parcela.AgrupadorId == null).Sum(parcela => parcela.Saldo) : 0;
        public decimal TotalPagoParcelas => Parcelas?.Sum(x => x.ValorPago) ?? 0;
        public decimal TotalCanceladoParcelas => Parcelas?.Where(parcela => parcela.SituacaoId == SituacaoReceitaParcela.Cancelado.Id).Sum(x => x.Valor) ?? 0;
        public int QuantidadeParcela => Parcelas?.Count(x=> x.IsAgrupador == false && x.IsAntecipador == false) ?? 0;
        public int QuantidadeParcelasPagas => Parcelas?.Count(x => x.SituacaoId == SituacaoReceitaParcela.Pago.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) ?? 0;
        public DateTime? PrimeiroVencimento => Parcelas.Count > 0 && Parcelas != null ? Parcelas.Where(x => x.Parcela == 1).Count() > 0 ? Parcelas.Where(x => x.Parcela == 1).First().DataVencimento : null : null; //Parcelas.First().DataVencimento : null ;
       // public DateTime? UltimoVencimento => Parcelas.Count > 0 ? Parcelas.Max(x => x.DataVencimento) : null;

        public DateTime? DataUltimoPagamento => Parcelas.Count > 0 && Parcelas != null ? Parcelas.Where(x => x.SituacaoId == SituacaoReceitaParcela.Pago.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)?.OrderBy(x => x.UltimaDataPagamento)?.LastOrDefault()?.UltimaDataPagamento ?? null : null;
        public decimal ValorParcelaAtual => Parcelas.Count > 0 && Parcelas != null ? Parcelas.Where(x=> (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && x.AgrupadorId == null).OrderBy(t => Math.Abs((t.DataVencimento - DateTime.Now).Ticks)).FirstOrDefault()?.Valor ?? 0 : 0;
        public decimal ValorParcelaDoMesAtual => ParcelaDoMes(DateTime.Today)?.Valor ?? 0;
        // public decimal ValorParcelaDoMes => Parcelas.Count > 0 && Parcelas != null ? Parcelas.Where(x=> (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && x.AgrupadorId == null && !x.IsAntecipador).Where(p => p.DataVencimento.Month == DateTime.Today.Month).OrderBy(p => p.Parcela).FirstOrDefault()?.Valor ?? 0 : 0;
        public decimal SaldoAmortizacao => Parcelas.Count > 0 && Parcelas != null ? Parcelas.Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && !x.IsAgrupador && !x.IsAntecipador).OrderBy(t => t.DataVencimento).FirstOrDefault()?.SaldoAmortizacaoInicioPeriodoCorrigido ?? 0 : 0;//Parcelas != null ? Parcelas.Where(parcela => (parcela.SituacaoId == SituacaoReceitaParcela.Aberto.Id || parcela.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && parcela.AgrupadorId == null).Sum(parcela => parcela.Amortizacao) : 0;
        public decimal SaldoAmortizacaoEmDia => CalcularSaldoAmortizacaoEmDia(DateTime.Today);
        // public decimal SaldoAmortizacaoEmDia => Parcelas.Count > 0 && Parcelas != null ? Parcelas.Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && x.DataVencimento >= DateTime.Today && !x.IsAgrupador && !x.IsAntecipador).OrderBy(t => t.DataVencimento).FirstOrDefault()?.SaldoAmortizacaoInicioPeriodoCorrigido ?? 0 : 0;
        public decimal SaldoAmortizacaoInicial => Parcelas?.OrderBy(x => x.Parcela).FirstOrDefault()?.SaldoAmortizacaoInicioPeriodoCorrigido ?? 0;
        public int QuantidadeParcelaFinanciamento => Parcelas?.Where(x => x.Receita?.TipoId == TipoReceita.Titulo.Id).Count() ?? 0;
        public int QuantidadeParcelaPagasFinanciamento => Parcelas?.Where(x => x.Receita?.TipoId == TipoReceita.Titulo.Id).Count(x => x.SituacaoId == SituacaoReceitaParcela.Pago.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) ?? 0;

        public int QuantidadeParcelaRestante => Parcelas?.Where(x => x.SituacaoId == SituacaoReceitaParcela.Aberto.Id && x.AgrupadorId == null).Count() ?? 0;

        public Receita()
        { 
            Parcelas = new List<ReceitaParcela>();
            Classificacoes = new List<ReceitaClassificacao>();
            GerarBoletoAutomatico = true;
            RealizarCobrancaAutomatica = true;
            Documentos = new List<ReceitaDocumento>();
        }

        public void AtualizarValor()
        {
            Valor = Math.Round( Parcelas.Where(x => x.AgrupadorId == null && x.SituacaoId != SituacaoReceitaParcela.Cancelado.Id && x.SituacaoId != SituacaoReceitaParcela.Aditado.Id).Sum(x => x.Valor),2);
        }

        /*public DateTime? UltimoVencimento
        {
            get
            {
                if (Parcelas == null || Parcelas.Count == 0)
                    return null;

                return Parcelas.Max(p => p.DataVencimento);
            }
        }*/



        /*public decimal SaldoParcelasAtrasadas0a30
       {
           get
           {
               if (Parcelas == null || Parcelas.Count == 0)
                   return 0;

               var hoje = DateTime.Today;
               var limiteInferior = hoje.AddDays(-30);

               return Parcelas
                .Where(p =>
                    p.Saldo > 0 &&
                    p.DataVencimento < hoje &&
                    (hoje - p.DataVencimento).TotalDays <= 30
                )
                .Sum(p => p.Saldo);

           }
       }

         public decimal SaldoParcelasAtrasadas31a90
         {
             get
             {
                 if (Parcelas == null || Parcelas.Count == 0)
                     return 0;

                 var hoje = DateTime.Today;

                 return Parcelas
                     .Where(p =>
                         p.Saldo > 0 &&
                         p.DataVencimento < hoje &&
                         (hoje - p.DataVencimento).TotalDays > 30 &&
                         (hoje - p.DataVencimento).TotalDays <= 90
                     )
                     .Sum(p => p.Saldo);
             }
         } 


         public decimal SaldoParcelasAtrasadasAcima90
         {
             get
             {
                 if (Parcelas == null || Parcelas.Count == 0)
                     return 0;

                 var hoje = DateTime.Today;

                 return Parcelas
                     .Where(p =>
                         p.Saldo > 0 &&
                         p.DataVencimento < hoje &&
                         (hoje - p.DataVencimento).TotalDays > 90
                     )
                     .Sum(p => p.Saldo);
             }
         }*/

        public decimal CalcularSaldoAmortizacaoEmDia(DateTime dataReferencia)
        {
            if(Parcelas.IsNullOrEmpty())
                return 0;

            var parcelasEmDia = Parcelas.Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && x.DataVencimento >= dataReferencia && !x.IsAgrupador && !x.IsAntecipador).OrderBy(t => t.DataVencimento);
            var parcelaAtual = parcelasEmDia.Where(p => p.DataVencimento.Month == dataReferencia.Month && p.DataVencimento.Year == dataReferencia.Year && p.DataVencimento >= dataReferencia).OrderBy(p => p.Parcela).FirstOrDefault();
            var parcelasAVencer = parcelasEmDia.Where(p => p.Parcela != (parcelaAtual?.Parcela ?? 0));
            
            return (parcelaAtual?.Valor ?? 0) + (parcelasAVencer.FirstOrDefault()?.SaldoAmortizacaoInicioPeriodoCorrigido ?? 0);
        }

        public ReceitaParcela ParcelaDoMes(DateTime dataReferencia)
        {
            ReceitaParcela parcela;
            if(Parcelas.Count > 0 && Parcelas != null)
                parcela = Parcelas.Where(x=> (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && x.AgrupadorId == null && !x.IsAntecipador)
                                .Where(p => p.DataVencimento.Month == dataReferencia.Month && p.DataVencimento.Year == dataReferencia.Year && p.DataVencimento >= dataReferencia)
                                .OrderBy(p => p.Parcela)
                                .FirstOrDefault();
            else
                parcela = null;
            
            return parcela;
        }
    }
}
