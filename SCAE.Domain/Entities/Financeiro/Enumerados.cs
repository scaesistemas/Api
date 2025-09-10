using System.ComponentModel;

namespace SCAE.Domain.Entities.Financeiro
{
    public enum EnumTipoParcela
    {
        [Description("Não Informado")] NaoInformado = 0,
        [Description("Única")] Unica = 1,
        [Description("Parcelada")] Parcelada = 2,
        [Description("Recorrente")] Recorrente = 3
    }

    public enum EnumSituacaoDespesa
    {
        [Description("Pago")] Pago,
        [Description("A Pagar")] A_Pagar,
        [Description("Cancelada")] Cancelada,
    }

    public enum EnumSituacaoReceita
    {
        [Description("Recebida")] Recebida,
        [Description("A Receber")] A_Receber,
        [Description("Vencida")] Vencida,
        [Description("Cancelada")] Cancelada,
        [Description("Agrupada")] Agrupada,
    }

    public enum EnumSituacaoCheque
    {
        [Description("A Compensar")] A_Compensar,
        [Description("Compensado")] Compensado,
        [Description("Devolvido")] Devolvido,
        [Description("Cancelado")] Cancelado
    }

    public enum EnumOrigemParcela
    {
        [Description("Padrão")] Padrao,
        [Description("PRICE")] PRICE,
        [Description("SAC")] SAC,
        [Description("Entrada")] Entrada,
        [Description("Avulsa")] Avulsa,
        [Description("Serviços")] Servicos,
        [Description("Agrupada")] Agrupada
    }

    public enum EnumProtesto
    {
        [Description("Não Informado")] NaoInformado = 0,
        [Description("Protestar")] Protestar = 1,
        [Description("Não Protestar")] NaoProtestar = 2,
        [Description("Cancelar Protesto")] CancelarProtesto = 3
    }
    public enum TipoOperacaoAjusteAmortizacao
    {
        [Description("Não Informado")] AjustarPeloValorParcela = 1,
        [Description("Protestar")] AjustarPeloValorAmortizacao = 2,

    }
}
