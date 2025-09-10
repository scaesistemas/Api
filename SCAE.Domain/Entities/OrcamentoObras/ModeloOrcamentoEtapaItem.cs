using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("modeloorcamentoetapaitem", Schema = "orcamentoobras")]
    public class ModeloOrcamentoEtapaItem : IEntity
    {
        public int Id { get; set; }
        public int ModeloEtapaId { get; set; }
        public ModeloOrcamentoEtapa ModeloEtapa { get; set; }

        //Ao aplicar o modelo será necessário aplicar os valores de acordo com os dados usados no orçamento
        public ModeloComposicao Composicao { get; set; }
        public decimal Quantidade { get; set; }
        //Ao aplicar o modelo será necessário aplicar os valores de acordo com os dados usados no orçamento

        //Valores salvos na hora da criação do modelo ou na edição do modelo
        public decimal ValorDesoneradoItemOriginal => Composicao?.ValorOriginalDesonerado ?? 0;
        public decimal ValorNaoDesoneradoItemOriginal => Composicao?.ValorOriginalNaoDesonerado ?? 0;

        public decimal ValorTotalItemDesonerado => ValorDesoneradoItemOriginal * Quantidade;
        public decimal ValorTotalItemNaoDesonerado => ValorNaoDesoneradoItemOriginal * Quantidade;

    }

}