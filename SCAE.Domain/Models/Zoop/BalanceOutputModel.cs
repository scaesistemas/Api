using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Zoop
{
    public class BalanceOutputModel
    {
        public string Data { get; set; }
        public decimal ValorAtual { get; set; }
        public decimal ValorAtualBloqueado { get; set; }
        public List<BalanceOutputItemModel> Itens { get; set; }

        public BalanceOutputModel()
        {
            Itens = new List<BalanceOutputItemModel>();
        }
    }

    public class BalanceOutputItemModel
    {
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public decimal SaldoAtual { get; set; }
    }
}
