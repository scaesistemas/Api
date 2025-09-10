namespace SCAE.Domain.Models.Vendas.Contrato
{
    public class DistratoContratoModel
    {
        public decimal ParcelasLiquidadas { get; set; }
        public decimal RetencoesTotal => RetencoesContratuais.EncargosAtrasados + RetencoesContratuais.DebitosImpostos + RetencoesContratuais.ComissaoCorretagem + RetencoesContratuais.PenaContratual;
        public RetencoesContratuais RetencoesContratuais { get; set; }
        public decimal ValorDevolvido => ParcelasLiquidadas - RetencoesTotal;
    }
    public class RetencoesContratuais
    {
        public decimal EncargosAtrasados { get; set; }
        public decimal DebitosImpostos { get; set; }
        public decimal ComissaoCorretagem { get; set; }
        public decimal PenaContratual { get; set; }
    }
}