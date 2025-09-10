using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Almoxarifado;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Owned]
    public class ModeloComposicao
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int UnidadeMedidaId { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public int ClasseId { get; set; }
        public ClasseComposicao Classe { get; set; }
        public int OrigemId { get; set; }
        public OrigemDados Origem { get; private set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal ValorOriginalDesonerado { get; set; }
        public decimal ValorOriginalNaoDesonerado { get; set; }
    }
}
