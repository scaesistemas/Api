using SCAE.Domain.Interfaces.Shared;
using SCAE.Framework.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("orcamentoetapa", Schema = "orcamentoobras")]
    public class OrcamentoEtapa : IEntity
    { 
        public int Id { get; set; } 
        public int OrcamentoId { get; set; }
        public OrcamentoObras Orcamento { get; private set; }
        public int? EtapaPaiId { get; set; }
        public OrcamentoEtapa EtapaPai { get; private set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }
        public ICollection<OrcamentoEtapaItem> Itens { get; set; }

        [NotMapped]
        public List<OrcamentoEtapa> Children { get; set; }
        public decimal ValorTotalDesonerado => Soma(true);
        public decimal ValorTotalNaoDesonerado => Soma(false);

        public decimal ValorTotalItemDesonerado => ValorTotalDesonerado * Quantidade;
        public decimal ValorTotalItemNaoDesonerado => ValorTotalDesonerado * Quantidade;

        public decimal ValorTotalDesoneradoComBDI => ValorTotalDesonerado * (Orcamento?.PercentualBDI / 100) ?? 0;
        public decimal ValorTotalNaoDesoneradoComBDI => ValorTotalNaoDesonerado * (Orcamento?.PercentualBDI /100) ?? 0;

        public OrcamentoEtapa()
        {
            Itens = new List<OrcamentoEtapaItem>();
        } 

        public decimal Soma(bool desonerado) 
        {
            if (Orcamento == null) return 0;
            if (Orcamento.Estado == null) return 0;
            if (Itens.Count < 1) return 0;
            var valorNome = desonerado ? "ValorDesonerado" : "ValorNaoDesonerado";

            var estadoPropriedade = PropriedadeHelper.PegarPropriedadePorNome<InsumoEstado>(Orcamento.Estado.Nome);

            if (estadoPropriedade != null)
            {
                decimal valorTotal = 0;
                foreach (var item in Itens)
                {
                    var estadoValor = estadoPropriedade.GetValue(item.Composicao.Estado);
                    var valorPropriedade = typeof(InsumoEstadoValor).GetProperty(valorNome);
                    var valor = valorPropriedade.GetValue(estadoValor);

                    valorTotal += (decimal)valor * item.Quantidade;
                }
                if (Children == null) 
                    return valorTotal;

                foreach (var child in Children) 
                {
                    valorTotal += child.Soma(desonerado);
                }

                return valorTotal;
            }
            else
                return 0;
            
        }
    }
}
