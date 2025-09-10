namespace SCAE.Domain.Models.Projeto
{
    public class OrcadoRealizadoModel
    {
        public int EtapaId { get; set; }
        public string Etapa { get; set; }
        public int ProdutoId { get; set; }
        public string Produto { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal QuantidadeOrcado { get; set; }
        public decimal QuantidadeConsumida { get; set; }
        public decimal ValorUnitarioOrcado { get; set; }
        public decimal ValorUnitarioConsumido { get; set; }
    }
}
