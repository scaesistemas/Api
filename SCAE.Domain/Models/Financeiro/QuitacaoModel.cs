using System;

namespace SCAE.Domain.Models.Financeiro
{
    public class QuitacaoModel
    {
        public DateTime Data { get; set; }
        public int TipoAmortizacaoId { get; set; }
        public int TipoQuitacaoId { get; set; }
    }

    public enum TipoQuitacao
    {
        Padrao = 1,
        TodasAsParcelas = 2,
        QuantidadeDeParcelas = 3
    }
}
