using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("receitaparcela", Schema = "financeiro")]
    public class ReceitaParcela : IEntity
    {
        private ValoresAdicionais _valoresAdicionais;
        public int Id { get; set; }
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }
        [Required] public int Parcela { get; set; }
        public string ParcelaStr => $"{Parcela}/{Receita?.QuantidadeParcela}";
        [MaxLength(25)] public string ContratoNumeroSequencia { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataVencimentoOriginal { get; set; }
        [Required] public decimal Valor { get; set; }
        [StringLength(60)] public string LinhaDigitavelBoleto { get; set; }
        public string QrCode { get; set; }
        public string CodigoBarra { get; set; }
        public int SituacaoId { get; set; }
        public virtual SituacaoReceitaParcela Situacao { get; private set; }

        [StringLength(20)] public string NossoNumero { get; set; }
        public int? TipoGatewayId { get; set; }
        public TipoGateway TipoGateway { get; set; }
        public int? Remessa { get; set; }
        public DateTime? DataRemessa { get; set; }
        public Encargo EncargoFinanceiro { get; set; }
        public string CodigoMovimentoRetorno { get; set; }
        [MaxLength(45)] public string CodigoZoop { get; set; }
        [MaxLength(60)] public string Instrucao1 { get; set; }
        [MaxLength(60)] public string Instrucao2 { get; set; }
        [MaxLength(60)] public string Instrucao3 { get; set; }
        public string UrlBoleto { get; set; }
        public int? AgrupadorId { get; set; }
        public ReceitaParcela Agrupador { get; set; }
        public int? AntecipadorId { get; set; }
        public bool IsAgrupador { get; set; }
        public bool IsAntecipador { get; set; }
        public AntecipacaoAmortizacao AntecipacaoAmortizacao { get; set; }
        public int? ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public int TipoOperacaoId { get; set; }
        public TipoOperacaoFinanceira TipoOperacao { get; set; }

        public string ParcelasAgrupadasNumero { get; set; }

        public ICollection<ReceitaBaixa> Baixas { get; set; }
        public TipoServicoParcela TipoServico { get; set; }
        public int? TipoServicoId { get; set; }

        public DateTime? DataEnvioCobranca { get; set; }
        public DateTime? DataEnvioCobrancaSms { get; set; }
        public DateTime? DataEnvioCobrancaWhatsapp { get; set; }


        public AntecipacaoComprovante AntecipacaoComprovante { get; set; }

        public decimal Amortizacao { get; set; }
        public decimal Juros { get; set; }
        public decimal SaldoAmortizacaoInicioPeriodoCorrigido { get; set; }
        public decimal SaldoAmortizacaoFimPeriodoCorrigido { get; set; }
        public decimal SaldoAmortizacaoPeriodoOriginal { get; set; }
        public decimal CorrecaoSaldo { get; set; }

        public SplitParcela? SplitPagamento { get; set; }

        public ValoresAdicionais ValoresAdicionais
        {
            get
            {
                if (_valoresAdicionais == null)
                {
                    _valoresAdicionais = new ValoresAdicionais();
                }
                return _valoresAdicionais;
            }
            set
            {
                _valoresAdicionais = value;
            }
        }
        public string Observacao { get; set; }
        public bool Conciliado { get; set; }
        public ICollection<ReceitaTransacao> Transacoes { get; set; }

        public decimal Saldo => Baixas != null && SituacaoId != SituacaoReceitaParcela.Pago.Id && !AgrupadorId.HasValue ? Valor - Baixas.Where(x => !x.Cancelado).Sum(baixa => baixa.Valor) : 0;
        public decimal ValorPago => Baixas != null ? Baixas.Where(x => !x.Cancelado).Sum(baixa => baixa.Total) : 0;
        public DateTime? UltimaDataPagamento => Baixas != null && Baixas.Count > 0 && Baixas.Any(x => !x.Cancelado) ? Baixas.Where(x => !x.Cancelado).LastOrDefault().DataPagamento : null;
        public string UltimaFormaPagamento => Baixas != null && Baixas.Count > 0 && Baixas.Any(x => !x.Cancelado) ? Baixas.Where(x => !x.Cancelado).LastOrDefault().FormaPagamento?.Nome : null;
        public decimal ValorComTaxas => Valor + (ValoresAdicionais?.TaxaBoleto ?? 0) + (ValoresAdicionais?.ValorFixoTaxaAdicional ?? 0);

        public ReceitaTransacao UltimaTransacao => Transacoes.Any() ? Transacoes.OrderBy(x => x.DataEmissao).LastOrDefault() : null;
        public decimal ValorAPagarComJurosEMulta => Saldo + CalcularJurosEMulta();
        [NotMapped]
        public int TipoReceitaId { get; set; }
 

        public decimal DescontoAplicado
        {
            get
            {
                // Verifica se há desconto configurado e se há dias de desconto definidos
                if (EncargoFinanceiro?.DescontoVencimento > 0 && EncargoFinanceiro?.DiasDescontoVencimento >= 0)
                {
                    // Data limite para o desconto é calculada subtraindo os dias de desconto do vencimento
                    DateTime dataLimiteDesconto = DataVencimento.Year > DateTime.MinValue.Year ? DataVencimento.Date.AddDays(-EncargoFinanceiro.DiasDescontoVencimento) : DateTime.MinValue;

                    // O desconto é aplicado apenas se a data atual for antes da data limite
                    if (DateTime.Now.Date <= dataLimiteDesconto)
                    {
                        return Valor * (EncargoFinanceiro.DescontoVencimento / 100);
                    }
                }

                return 0m;  
            }
        }

       /* public decimal JurosAplicado
        {
            get
            {
                
                if (EncargoFinanceiro?.JurosDia > 0 && DateTime.Now.Date > DataVencimento.Date)
                {
                    
                    int diasAtraso = (DateTime.Now.Date - DataVencimento.Date).Days;

                    
                    decimal juros = Valor * (EncargoFinanceiro.JurosDia / 100) * diasAtraso;

                    return Math.Round(juros, 2);
                }

                return 0m; 
            }
        }*/

        public decimal JurosAplicado
        {
            get
            {
                // Se houver baixas, soma o juros das baixas
                if (Baixas != null && Baixas.Any(b => !b.Cancelado))
                {
                    decimal totalJuros = Baixas
                      .Where(b => !b.Cancelado)
                      .Sum(b => b.Juros);

                    return Math.Round(totalJuros, 2);
                }

                // Caso não haja baixas, calcula o juros por atraso
                if (EncargoFinanceiro?.JurosDia > 0 && DateTime.Now.Date > DataVencimento.Date)
                {
                    int diasAtraso = (DateTime.Now.Date - DataVencimento.Date).Days;
                    decimal juros = Valor * (EncargoFinanceiro.JurosDia / 100) * diasAtraso;
                    return Math.Round(juros, 2);
                }

                return 0m;
            }
        }




        public decimal MultaAplicado
        {
            get
            {
                if (Baixas != null && Baixas.Any(b => !b.Cancelado))
                {
                    
                    decimal totalMulta = Baixas
                .Where(b => !b.Cancelado)
                .Sum(b => b.Multa);

                    return Math.Round(totalMulta, 2);
                }

                // Verifica se há multa configurados e se a parcela está vencida
                if (EncargoFinanceiro?.Multa > 0 && DateTime.Now.Date > DataVencimento.Date)
                {
                
                    decimal multa = Valor * (EncargoFinanceiro.Multa / 100);
                    return Math.Round(multa, 2);
                }

                return 0m;
            }
        }




        public ReceitaParcela()
        {
            SituacaoId = SituacaoReceitaParcela.Aberto.Id;
            EncargoFinanceiro = new Encargo();
            Baixas = new List<ReceitaBaixa>();
            Transacoes = new List<ReceitaTransacao>();
            IsAgrupador = false;
        }

        public void AtualizarInstrucao(Contrato contrato, Empreendimento.Empreendimento empreendimento, Receita receita, int totalParcela, int? QuantidadeLotesAdicionais = null)
        {
            var nomeGrupo = empreendimento.TipoId == TipoEmpreendimento.Loteamento.Id ? "Qd" : "Gp";

            Instrucao1 = $"Contrato:{contrato.Numero}-{contrato.Sequencia} | {TipoReceita.Obter(receita.TipoId).Nome} | {OrganizarNumeroParcela(receita, totalParcela)}";

            if (Instrucao1.Length > 60)
                Instrucao1 = Instrucao1.Substring(0, 60);

            if(QuantidadeLotesAdicionais.HasValue && QuantidadeLotesAdicionais > 0)
            {
                Instrucao2 = $"{empreendimento.Tipo.Nome}: {empreendimento.Nome} | referente a {QuantidadeLotesAdicionais.Value + 1} {contrato.UnidadePrincipal.Tipo.Nome}s";
            }
            else
            {
                Instrucao2 = $"{empreendimento.Tipo.Nome}: {empreendimento.Nome} | {nomeGrupo}: {contrato.UnidadePrincipal.Grupo.Nome}, {contrato.UnidadePrincipal.Tipo.Nome}: {contrato.UnidadePrincipal.Nome}";
            }

            if (Instrucao2.Length > 60)
            {
                Instrucao3 = Instrucao2.Substring(60);
                Instrucao2 = Instrucao2.Substring(0, 60);
            }

        }

        private string OrganizarNumeroParcela(Receita receita, int totalParcela)
        {

            if (!IsAgrupador)
            {
                return $" Parcela: {Parcela.ToString()} de {totalParcela}";
            }
            else
            {
                var instrucao = " P. Agrupadas: ";
                var parcelasAgrupadas = receita.Parcelas.Where(x => x.AgrupadorId != null && x.AgrupadorId == Id).ToList();
                if (parcelasAgrupadas.Count() <= 4)
                {

                    for (var i = 0; i < parcelasAgrupadas.Count(); i++)
                    {
                        instrucao += parcelasAgrupadas[i].Parcela.ToString();

                        if (i < parcelasAgrupadas.Count() - 2)
                        {
                            instrucao += ",";
                        }
                        else if (i == parcelasAgrupadas.Count() - 2)
                        {
                            instrucao += " e ";
                        }
                    }
                    return instrucao;
                }
                else
                {
                    instrucao += $"{ parcelasAgrupadas[0].Parcela.ToString()},{parcelasAgrupadas[1].Parcela.ToString()}..{parcelasAgrupadas[parcelasAgrupadas.Count - 2].Parcela.ToString()} e {parcelasAgrupadas[parcelasAgrupadas.Count - 1].Parcela.ToString()}";
                    return instrucao;
                }

            }

        }

        public bool Vencida(DateTime? dataReferencia = null)
        {
            dataReferencia = dataReferencia ?? DateTime.Today;
            return DataVencimento.CompareTo(dataReferencia.Value) < 0;
        }

        decimal CalcularJurosEMulta()
        {
            if (DataVencimento >= DateTime.Today)
                return 0;

            if(Saldo == 0)
                return 0;

            var diasJuros = (DateTime.Today - DataVencimento).Days;
            var jurosEMulta = EncargoFinanceiro?.Multa + (EncargoFinanceiro?.JurosDia * diasJuros) ?? 0;

            return (jurosEMulta * Saldo) / 100;
        }

    }

    [Owned]
    public class ValoresAdicionais
    {
        public decimal Gestao { get; set; }
        public decimal ValorMPI { get; set; }
        public decimal PercentualMPI { get; set; }
        public decimal ValorDFI { get; set; }
        public decimal PercentualDFI { get; set; }
        public bool IsDFIFixo { get; set; }
        public decimal CorrecaoIndice { get; set; }
        public decimal TaxaBoleto { get; set; }

        #region taxas adicionais
        public string NomeTaxaAdicional { get; set; }
        public decimal ValorFixoTaxaAdicional { get; set; }
        #endregion
    }

    [Owned]
    public class SplitParcela
    {
        public string TipoSplit {  get; set; }
        public int GalaxyPayId { get; set; }
        public int Valor { get; set; }
    }

}
