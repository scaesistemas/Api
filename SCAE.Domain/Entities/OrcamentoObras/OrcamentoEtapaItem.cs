using SCAE.Domain.Interfaces.Shared;
using SCAE.Framework.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("orcamentoetapaitem", Schema = "orcamentoobras")]
    public class OrcamentoEtapaItem : IEntity
    {
        public int Id { get; set; }
        public int EtapaId { get; set; }
        public OrcamentoEtapa Etapa { get; private set; }
        public int ComposicaoId { get; set; }
        public Composicao Composicao { get; set; }
        public decimal Quantidade { get; set; }

        public decimal ValorDesoneradoItem => GetValor(true);
        public decimal ValorNaoDesoneradoItem => GetValor(false);

        //public decimal ValorItem => Etapa != null ? (Etapa.Orcamento.EncargosDesonerados ? ValorDesoneradoItem : ValorNaoDesoneradoItem) : 0;

        public decimal ValorTotalItemDesonerado => ValorDesoneradoItem * Quantidade;
        public decimal ValorTotalItemNaoDesonerado => ValorNaoDesoneradoItem * Quantidade;

        //public decimal ValorTotalItem => Etapa != null ? (Etapa.Orcamento.EncargosDesonerados ? ValorDesoneradoItem * Quantidade : ValorNaoDesoneradoItem * Quantidade) : 0;

        public decimal ValorDesoneradoItemComBDI => ValorDesoneradoItem + (ValorDesoneradoItem * Etapa?.Orcamento.PercentualBDI / 100 ?? 0);
        public decimal ValorNaoDesoneradoItemComBDI => ValorNaoDesoneradoItem + (ValorNaoDesoneradoItem * Etapa?.Orcamento.PercentualBDI/100 ?? 0);

        public decimal ValorTotalItemDesoneradoComBDI => ValorDesoneradoItemComBDI * Quantidade;
        public decimal ValorTotalItemNaoDesoneradoComBDI => ValorNaoDesoneradoItemComBDI * Quantidade;


        public decimal GetValor(bool desonerado) 
        {
            if (Etapa == null) return 0;
            if (Etapa.Orcamento == null) return 0;
            if (Etapa.Orcamento.Estado == null) return 0;

            string valorNome;
            if (desonerado)
                valorNome = "ValorDesonerado";
            else
                valorNome = "ValorNaoDesonerado";

            var estadoPropriedade = PropriedadeHelper.PegarPropriedadePorNome<InsumoEstado>(Etapa.Orcamento.Estado.Nome);
            var estadoValor = estadoPropriedade.GetValue(Composicao.Estado);
            var valor = typeof(InsumoEstadoValor).GetProperty(valorNome);

            return (decimal) valor.GetValue(estadoValor);
        }
    }
}