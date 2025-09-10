using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("modeloorcamentoetapa", Schema = "orcamentoobras")]
    public class ModeloOrcamentoEtapa : IEntity
    {
        public int Id { get; set; }
        public int? ModeloEtapaPaiId { get; set; }
        public ModeloOrcamentoEtapa ModeloEtapaPai { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }
        public ICollection<ModeloOrcamentoEtapaItem> Itens { get; set; }

        /// <summary>
        /// Usado apenas para entregar as etapas filhas de maneira organizada. Será um em formato de árvore.
        /// </summary>
        [NotMapped]
        public ICollection<ModeloOrcamentoEtapa> Children { get; set; }
        [NotMapped]
        public int? OrigemId { get; set; }

        //Definir os valores com base nos itens
        public decimal ValorTotalDesonerado => Itens?.Select(x => x.ValorTotalItemDesonerado)?.Sum() ?? 0;
        public decimal ValorTotalNaoDesonerado => Itens?.Select(x => x.ValorTotalItemNaoDesonerado)?.Sum() ?? 0;

        public ModeloOrcamentoEtapa()
        {
            Itens = new List<ModeloOrcamentoEtapaItem>();
            Children = new List<ModeloOrcamentoEtapa>();
        }
    }

}
