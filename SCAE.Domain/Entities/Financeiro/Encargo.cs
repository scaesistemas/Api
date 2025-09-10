using Microsoft.EntityFrameworkCore;

namespace SCAE.Domain.Entities.Financeiro
{
    [Owned]
    public class Encargo
    {
        public decimal JurosDia { get; set; }
        public decimal Multa { get; set; }
        public decimal DescontoVencimento { get; set; }
        public int DiasDescontoVencimento { get; set; }
        public bool IsDescontoVencimentoPercentual { get; set; }
        public decimal DescontoAntecipacao { get; set; }
        public decimal CorrecaoMonetaria { get; set; }
        public int DiasAposVencimentoNaoReceber { get; set; }
        public int DiasProtesto { get; set; }
        public int DiasNegativacao { get; set; }

        public Encargo(decimal jurosDia, decimal multa, decimal descontoVencimento, int diasDescontoVencimento,
            decimal descontoAntecipacao,int diasAposVencimentoNaoReceber, int diasProtesto, decimal correcaoMonetaria, int diasNegaticao = 0, bool isDescontoVencimentoPercentual = true)
        {
            JurosDia = jurosDia;
            Multa = multa;
            DescontoVencimento = descontoVencimento;
            DiasDescontoVencimento = diasDescontoVencimento;
            DescontoAntecipacao = descontoAntecipacao;
            DiasAposVencimentoNaoReceber = diasAposVencimentoNaoReceber;
            DiasProtesto = diasProtesto;
            CorrecaoMonetaria = correcaoMonetaria;
            DiasNegativacao = diasNegaticao;
            IsDescontoVencimentoPercentual = isDescontoVencimentoPercentual;
        }

        public Encargo()
        {

        }
    }
}
