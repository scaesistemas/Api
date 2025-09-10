using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class ExcelCentroCustoModel
    {
        public string Codigo { get; set; }
        public int? Categorias { get; set; }
        public string Nome { get; set; }
        public string CodigoPai { get; set; }
        public CentroCusto CentroCustoPai { get; set; }
        public string Ativo { get; set; }
        public int Linha { get; set; }
    }
}
