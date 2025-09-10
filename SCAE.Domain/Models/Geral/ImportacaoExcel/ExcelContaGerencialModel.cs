using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class ExcelContaGerencialModel
    {
        public string Codigo { get; set; }
        public int? Categorias { get; set; }
        public string Nome { get; set; }
        public string CodigoPai { get; set; }
        public ContaGerencial ContaGerencialPai { get; set; }
        public string Ativo { get; set; }
        public string Tipo { get; set; }
        public int Linha { get; set; }
    }
}
