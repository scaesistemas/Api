using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Zoop
{
    public class BalanceInputModel
    {
        [JsonProperty("items")] public Dictionary<string, BalanceInputSubModel> Items { get; set; }
    }

    public class BalanceInputSubModel
    {
        [JsonProperty("currentBalance")] public decimal ValorAtual { get; set; }
        [JsonProperty("currentBlockedBalance")] public decimal ValorAtualBloqueado { get; set; }
        [JsonProperty("items")] public List<BalanceInputItemModel> Itens { get; set; }
    }

    public class BalanceInputItemModel
    {
        [JsonProperty("date")] public DateTime DataHora { get; set; }
        [JsonProperty("description")] public string Descricao { get; set; }
        [JsonProperty("type")] public string Tipo { get; set; }
        [JsonProperty("amount")] public decimal Valor { get; set; }
        [JsonProperty("current_balance")] public decimal SaldoAtual { get; set; }
    }
}
