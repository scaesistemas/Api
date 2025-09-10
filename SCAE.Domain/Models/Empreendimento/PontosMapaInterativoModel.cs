namespace SCAE.Domain.Models.Empreendimento
{
    public class PontosMapaInterativoModel
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public int ZoomStep { get; set; }
        public MapaInterativoUnidade MapaInterativoUnidade { get; set; }

    }

    public class MapaInterativoUnidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int SituacaoId { get; set; }
    }
}
