using System;


namespace SCAE.Domain.Models.Financeiro.Relatorio
{
    public class RelatorioReceitaBoletoModel
    {
        public int NumeroContrato { get; set; }
        public int SequenciaContrato { get; set; }
        public int ParcelaNumero { get; set; }
        public string ClienteNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string UrlBoleto { get; set; }
        public bool BoletoGerado => !string.IsNullOrEmpty(UrlBoleto);
        public string TipoReceita { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string UnidadeQuadra { get; set; }
        public string UnidadeLote { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
        public string LinhaDigitavelBoleto { get; set; }
        public DateTime? DataCobranca { get; set; }
        public bool CobrancaEnviada => DataCobranca != null ? true : false;
        public bool PagamentoAutomatico { get; set; }
        public string EmpresaNome { get; set; }
        public string SituacaoParcelaNome { get; set; }
        public DateTime? UltimaDataPagamento { get; set; }

    }


}
