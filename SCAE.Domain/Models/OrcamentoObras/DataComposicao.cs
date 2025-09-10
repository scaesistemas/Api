
namespace SCAE.Domain.Models.OrcamentoObras
{
    public class DataComposicao
    {
        public int Mes { get; set; }
        public int Ano { get; set; }

        public string MesAno => Mes.ToString() + "/" + Ano.ToString();
    }
}
