using Newtonsoft.Json;
using System;


namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto
{
    public class RetornoModel
    {
        [JsonProperty("NumeroDocumento")] public string Documento { get; set; }
        [JsonProperty("Pagador")] public PagadorRetornoModel Doador { get; set; }
        [JsonProperty("DataVencimento")] public DateTime DataVencimento { get; set; }
        [JsonProperty("DataCredito")] public DateTime DataPagamento { get; set; }
        [JsonProperty("ValorTitulo")] public decimal ValorTitulo { get; set; }
        [JsonProperty("ValorJurosDia")] public decimal Juros { get; set; }
        [JsonProperty("ValorMulta")] public decimal Multa { get; set; }
        [JsonProperty("ValorDesconto")] public decimal Desconto { get; set; }
        [JsonProperty("ValorPago")] public decimal ValorPago { get; set; }
        [JsonProperty("CodigoMotivoOcorrencia")] public string CodigoOcorrencia { get; set; }
        [JsonProperty("DescricaoMotivoOcorrencia")] public string DescricaoOcorrencia { get; set; }
        [JsonProperty("ParcelaInformativo")] public string Situacao { get; set; }
        public string NumeroDocumentoSemZeroEsquerda => Documento.TrimStart(new Char[] { '0' });

        public string CodigoDescricaoOcorrencia => CodigoOcorrencia +" - "+ DescricaoOcorrencia;


    }

    public class PagadorRetornoModel
    {
        public string Nome { get; set; } 
        public string Telefone { get; set; } 
        public string Observacoes { get; set; } 
        public string CPFCNPJ { get; set; }
    }
}
