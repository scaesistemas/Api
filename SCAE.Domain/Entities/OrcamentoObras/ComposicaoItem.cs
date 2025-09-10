using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("composicaoitem", Schema = "orcamentoobras")]
    public class ComposicaoItem : IEntity
    {
        public int Id { get; set; }
        public int ComposicaoId { get; set; }
        public Composicao Composicao { get; private set; }
        public int? InsumoId { get; set; }
        public Insumo Insumo { get; private set; }
        public int? ComposicaoAuxiliarId { get; set; }
        public Composicao ComposicaoAuxiliar { get; private set; }
        public decimal Coeficiente { get; set; }

        //public decimal ValorPadraoDesonerado => Coeficiente * Insumo?.ValorPadraoDesonerado ?? 0;
        //public decimal ValorPadraoNaoDesonerado => Coeficiente * Insumo?.ValorPadraoNaoDesonerado ?? 0;
        //public decimal ValorDesonerado => Coeficiente * ObterValorDesonerado();
        //public decimal ValorNaoDesonerado => Coeficiente * ObterValorDesonerado();

        //private decimal ObterValorDesonerado()
        //{
        //    if (ComposicaoAuxiliar != null)
        //        return ComposicaoAuxiliar.Estado.ObterValorDesonerado(EstadoId);

        //    if (Insumo != null)
        //        return Insumo.Estado.ObterValorDesonerado(EstadoId);

        //    return 0;
        //}
        public InsumoEstado Estado => ObterEstados();

        public InsumoEstado ObterEstados()
        {
            if (ComposicaoAuxiliar != null)
                return ComposicaoAuxiliar.Estado;

            if (Insumo != null)
                return Insumo.Estado;

            return null;
        }

        public void SetComposicaoAuxiliar(Composicao composicaoAuxiliar) 
        {
           ComposicaoAuxiliar = composicaoAuxiliar;
        }

        public void SetComposicao(Composicao composicao) 
        {
            Composicao = composicao;
        }
    }
}
