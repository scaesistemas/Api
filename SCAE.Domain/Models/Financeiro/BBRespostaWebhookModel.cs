namespace SCAE.Domain.Models.Financeiro
{
    public class BBRespostaWebhookModel
    {
        public string Id { get; set; }
        public string DataRegistro { get; set; }
        public string DataVencimento { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorPagoSacado { get; set; }
        public int NumeroConvenio { get; set; }
        public int NumeroOperacao { get; set; }
        public int CarteiraConvenio { get; set; }
        public int VariacaoCarteiraConvenio { get; set; }
        public int CodigoEstadoBaixaOperacional { get; set; }
        public string DataLiquidacao { get; set; }
        public long InstituicaoLiquidacao { get; set; }
        public int CanalLiquidacao { get; set; }
        public int CodigoModalidadeBoleto { get; set; }
        public int TipoPessoaPortador { get; set; }
        public int IdentidadePortador { get; set; }
        public string NomePortador { get; set; }
        public int FormaPagamento { get; set; }
    }
}