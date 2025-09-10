
namespace SCAE.Domain.Models.OrcamentoObras
{
    public class ExcelSinapiModel
    {
        public string Localidade { get; set; }
        public string Data { get; set; }
        public string NomeClasse { get; set; }
        public string SiglaClasse { get; set; }

        public string DescricaoTipo1 { get; set; }
        public int SiglaTipo1 { get; set; }

        public string CodigoAgrupador { get; set; }
        public string DescricaoAgrupador { get; set; }

        public string CodigoComposicao { get; set; }
        public string DescricaoComposicao { get; set; }
        public string Unidade { get; set; }
        public string OrigemPreco { get; set; }
        public decimal CustoTotal { get; set; }

        public string TipoItem { get; set; }
        public string CodigoItem { get; set; }
        public string DescricaoItem { get; set; }
        public string UnidadeItem { get; set; }
        public string OrigemPrecoItem { get; set; }
        public decimal Coeficiente { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal CustoTotalItem { get; set; }

        public decimal CustoMaoDeObra { get; set; }
        public decimal PorcentagemMaoDeObra { get; set; }
        public decimal CustoMaterial { get; set; }
        public decimal PorcentagemMaterial { get; set; }
        public decimal CustoEquipamento { get; set; }
        public decimal PorcentagemEquipamento { get; set; }
        public decimal CustoServicoTerceiros { get; set; }
        public decimal PorcentagemServicoTerceiros { get; set; }
        public decimal CustoOutros { get; set; }
        public decimal PorcentagemOutros { get; set; }
        public decimal PorcentagemAtribuidoSP { get; set; }

        public string Vinculo {  get; set; }


    }
}
