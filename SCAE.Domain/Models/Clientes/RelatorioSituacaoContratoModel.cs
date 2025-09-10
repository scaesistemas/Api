using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Clientes
{

    public class RelatorioSituacaoContratoModel
    {

        public int NumeroContrato { get; set; }
        public int SequenciaContrato { get; set; }
        public string NomeSituacaoAtualContrato { get; set;}

        public int SituacaoContratoId { get; set; }
        public DateTime? DataSituacaoAtualContrato { get; set; }
        public DateTime DataEmissaoContrato { get; set; }
        public string EmpresaContratoNome { get; set; }

       // public int NumeroParcelaAtualFinanciamento { get; set; }
       // public int TotalParcelasFinanciamento { get; set; }
       // public decimal ValorParcelaAtualFinanciamento { get; set; }
        public decimal ValorTotalFinanciamento { get; set; }

        public string NomeEmpreendimento { get; set;}
        public string NomeQuadra { get; set; }
        public string NomeLote { get; set; }

        public string NomeCliente { get; set;}
        public string NomeUsuarioResponsavel { get; set; }

        public string EscrituraLote { get; set; }
        public string MatriculaLote { get; set; }
    }

    // 🔥 Classe pai com lista e totais
    public class RelatorioSituacaoContratoResult
    {
        public List<RelatorioSituacaoContratoModel> Contratos { get; set; } = new List<RelatorioSituacaoContratoModel>();

        // Totais
        public int TotalContratosEmAbertos { get; set; }

        public int TotalContratosPendentesAprovacao { get; set; }

        public int TotalContratosJuridico { get; set; }

        public int TotalContratosCancelados { get; set; }

        public int TotalContratosPropostaDevolvida { get; set; }

        public int TotalContratosAditados { get; set; }

        public int TotalContratosEmCobrancas { get; set; }

        public int TotalContratosQuitados { get; set; }


    }
}
