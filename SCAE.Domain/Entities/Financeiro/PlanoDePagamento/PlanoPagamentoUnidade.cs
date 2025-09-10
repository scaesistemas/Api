using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro.PlanoDePagamento
{
    [Table("planopagamentounidade", Schema = "financeiro")]

    public class PlanoPagamentoUnidade : PlanoPagamento, IEntity
    {
        public int Id { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }

        public PlanoPagamentoUnidade()
        {

        }
        public PlanoPagamentoUnidade(PlanoPagamentoModelo modelo,int unidadeId = 0)
        {
            Nome = modelo.Nome;
            IntervaloReajusteId = modelo.IntervaloReajusteId;
            TipoMesReajusteId = modelo.TipoMesReajusteId;
            TipoIndiceId = modelo.TipoIndiceId;
            TipoAmortizacaoId = modelo.TipoAmortizacaoId;
            TipoAnoInicioReajusteId = modelo.TipoAnoInicioReajusteId;
            JurosTabela = modelo.JurosTabela;
            TaxaGestao = modelo.TaxaGestao;
            IsDFIFixo = modelo.IsDFIFixo;
            SeguroMPI = modelo.SeguroMPI;
            SeguroDFI = modelo.SeguroDFI;
            ValorMetroQuadrado = modelo.ValorMetroQuadrado;
            ValorUnidade = modelo.ValorUnidade;
            TipoValorTotalId = modelo.TipoValorTotalId;
            Entrada = new ReceitaPlanoPagamento( modelo.Entrada);
            Intermediaria = new ReceitaPlanoPagamento(modelo.Intermediaria);
            Financiamento = new ReceitaPlanoPagamento(modelo.Financiamento);
            UnidadeId = unidadeId;
            TipoOperacaoId = modelo.TipoOperacaoId;
            TipoGatewayId = modelo.TipoGatewayId;
            ContaCorrenteId = modelo.ContaCorrenteId;
            TaxaBoleto = modelo.TaxaBoleto;
            EncargoFinanceiro = new Encargo(modelo.EncargoFinanceiro?.JurosDia ?? 0, modelo.EncargoFinanceiro?.Multa ?? 0, modelo.EncargoFinanceiro?.DescontoVencimento ?? 0, modelo.EncargoFinanceiro?.DiasDescontoVencimento ?? 0, modelo.EncargoFinanceiro?.DescontoAntecipacao ?? 0, modelo.EncargoFinanceiro?.DiasAposVencimentoNaoReceber ?? 0, modelo.EncargoFinanceiro?.DiasProtesto ?? 0, modelo.EncargoFinanceiro?.CorrecaoMonetaria ?? 0, modelo.EncargoFinanceiro?.DiasNegativacao ?? 0, modelo.EncargoFinanceiro?.IsDescontoVencimentoPercentual ?? true);
        }
    }
}
