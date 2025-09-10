using System;

namespace SCAE.Domain.Models.Financeiro.Relatorio
{
    public class RelatorioParcelasAditadasModel
    {
        public int ParcelaId { get; set; }
        public string NumeroSequenciaContrato { get; set; }
        public int NumeroContrato { get; set; }
        public int SequenciaContrato { get; set; }
        public DateTime? DataAditamento { get; set; }
        public string ClienteNome { get; set; }
        public string CorretorNome { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string UnidadeQuadra { get; set; }
        public string UnidadeLote { get; set; }
        public decimal ValorParcela { get; set; }
        public int ParcelaNumero { get; set; }
        public int TotalParcelas { get; set; }
        public DateTime? VencimentoParcela { get; set; }
        public DateTime? DataPagamentoParcela { get; set; }
        public decimal ValorPagoParcela { get; set; }
        public string TipoAditamentoNome { get; set; }

    }
}
