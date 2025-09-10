namespace SCAE.Domain.Models.Almoxarifado
{
    public class TransferenciaModel
    {
        public int AlmoxarifadoOrigemId { get; set; }
        public int AlmoxarifadoDestinoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
    }
}
