using System;

namespace SCAE.Domain.Models.Clientes
{
    public class RelatorioContratoAditadoModel
    {
        public int NumeroContrato { get; set; }
        public int SequenciaContrato { get; set; }
        public string NumeroSequenciaContrato { get; set; }
        public string NomeSituacaoAtualContrato { get; set; }
        public DateTime? DataAditamento { get; set; }
        public string TipoAditamentoNome { get; set; }

        public string NomeEmpreendimento { get; set; }
        public string NomeQuadra { get; set; }
        public string NomeLote { get; set; }

        public string NomeCliente { get; set; }
        public string NomeCorretor { get; set; }

        public decimal ValorTotalAditamento { get; set; }
        public decimal ValorTotalPagoAditamento { get; set; }
        public bool? AditamentoPago { get; set; }
 
    }
}
