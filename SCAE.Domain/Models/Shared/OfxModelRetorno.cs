using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Shared
{
    public class OfxModelRetorno
    {
        public List<OfxModelSugestao> OfxModelsSugestoes {  get; set; }
        public int EmpresaId { get; set; }
        //Saldo da conta corrente
        public decimal Saldo { get; set; }
    }

    public class OfxModelSugestao 
    {
        public OfxParserModel OfxParserModel { get; set; }
        public DespesaParcela DespesaParcelaSugerida { get; set; }
        public int? BaixaId { get; set; }
        public int FormaPagamentoId { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal ValorPago { get; set; }
        public bool Conciliado { get; set; }
    }
    public class OfxConfiabilidade
    {
        public bool NomeMatch { get; set; }
        public int QuantidadeMatches { get; set; }
        public bool Valor {  get; set; }
        public bool Data {  get; set; }
        public bool FitId { get; set; }
    }
}
