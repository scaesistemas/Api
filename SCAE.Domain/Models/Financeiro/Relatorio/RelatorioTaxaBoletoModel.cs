using System;
using System.Collections.Generic;
using System.Linq;

namespace SCAE.Domain.Models.Financeiro.Relatorio
{
    public class RelatorioTaxaBoletoModel
    {
        public List<RelatorioTaxaBoletoParcelaModel> Parcelas { get; set; }
        public int TotalParcelas => Parcelas.Count;
        public decimal TotalPagoTarifa => Parcelas.Sum(x => x.ParcelaValorTaxaBoleto);

    }

    public class RelatorioTaxaBoletoParcelaModel
    {
        public int ContratoNumero { get; set; }
        public int ContratoSequencia { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string GrupoNome { get; set; }
        public string UnidadeNome { get; set; }
        public int ParcelaNumero { get; set; }
        public decimal ParcelaValorTaxaBoleto { get; set; }
        public decimal ParcelaValorTaxaAdicional { get; set; }
        public string ParcelaNomeTaxaAdicional { get; set; }
        public DateTime? DataPagamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public string ContratoNumeroSequencia => ContratoNumero > 0 ? ContratoNumero + " - " + ContratoSequencia : "";

    }
}
