using System.Collections.Generic;
using System;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared
{
    public class BoletoBaseModel
    {
        public string CodigoInterno { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataLimiteRecebimento { get; set; }
        public decimal MultaPercentual { get; set; }
        public decimal JurosPercentual { get; set; }
        public int? DiasProtesto { get; set; }
        public int? DiasNegativacao { get; set; }

        public List<BoletoDescontoModel> Descontos { get; set; }
        public string? Instrucao1 { get; set; }
        public string? Instrucao2 { get; set; }
        public string? Instrucao3 { get; set; }
        public PagadorModel? Pagador { get; set; }
        public PagadorModel? Beneficiario { get; set; }
        public string? KeyTypePix { get; set; }
        public string? ChavePix { get; set; }
        public string? AssinanteDominio { get; set; }
        public bool CadastrarComQRCode { get; set; }


        public BoletoBaseModel()
        {
            Descontos = new List<BoletoDescontoModel>();
            Pagador = new PagadorModel();
        }

        public int DiasLimiteRecebimento()
        {
            return DataLimiteRecebimento.HasValue ? DataLimiteRecebimento.Value.Subtract(DataVencimento).Days : 59;
        }
    }

    public class BoletoDescontoModel
    {
        public bool Percentual { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLimite { get; set; }

        public BoletoDescontoModel()
        {
            Percentual = true;
        }
    }
}
