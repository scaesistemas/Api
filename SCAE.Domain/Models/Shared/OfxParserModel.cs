using System;
using System.Drawing;

namespace SCAE.Domain.Models.Shared;

public class OfxParserModel
{
    public string Descricao { get; set; }
    public DateTime Data {  get; set; }
    public decimal Valor { get; set; }
    public TipoTransacaoScae TipoTransacao { get; set; }
    public string Tipo { get; set; }
    public string TransactionId { get; set; }

    public enum TipoTransacaoScae { Despesa, Receita }
}
