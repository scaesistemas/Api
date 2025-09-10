using SCAE.Financeiro.Api.Models.Boleto.Shared;
using System;


namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto
{
    public class BoletoModel
    {
        public int NumeroContrato { get; set; }
        public string NossoNumero { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public bool AplicarJurosMulta { get; set; }
        public decimal PercentualJuros { get; set; }
        public decimal PercentualMulta { get; set; }
        public decimal PercentualDesconto { get; set; }
        public DateTime? DataJuros { get; set; }
        public DateTime? DataMulta { get; set; }
        public DateTime? DataDesconto { get; set; }
        public BeneficiarioModel Beneficiario { get; set; }
        public PagadorModel Pagador { get; set; }
        public string? Instrucao1 { get; set; }
        public string? Instrucao2 { get; set; }
        public string? Instrucao3 { get; set; }
    }
}
