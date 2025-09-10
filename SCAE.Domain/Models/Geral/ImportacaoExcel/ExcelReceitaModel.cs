using System;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class ExcelReceitaModel
    {
        public int ContratoId { get; set; }
        public int TipoReceitaId { get; set; }
        public int TotalParcelas { get; set; }
        public DateTime DataVencimentoInicial { get; set; }
        public decimal MaiorValor { get; set; }
    }
}
