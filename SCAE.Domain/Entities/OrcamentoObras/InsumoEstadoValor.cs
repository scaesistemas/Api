using Microsoft.EntityFrameworkCore;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Owned]
    public class InsumoEstadoValor
    {
        private decimal _coeficiente;

        public decimal ValorDesonerado { get; set; }
        public decimal ValorNaoDesonerado { get; set; }
        public decimal ValorTotalDesonerado => _coeficiente * ValorDesonerado;
        public decimal ValorTotalNaoDesonerado => _coeficiente * ValorNaoDesonerado;

        public InsumoEstadoValor AtualizaCoeficiente(decimal coeficiente)
        {
            _coeficiente = coeficiente;

            return this;
        }
    }
}
