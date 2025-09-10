using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioReceitaEmpreendimentoModel
    {
        public string EmpreendimentoNome { get; set; }
        public ICollection<TiposReceita> TiposReceita { get; set; }
        public decimal TotalValorGeral => TiposReceita?
            .Where(item => item.TotalValorTipo != 0)
            .Sum(item => item?.TotalValorTipo) ?? 0;
        public decimal TotalSaldoGeral => TiposReceita?
            .Where(item => item.TotalSaldoTipo != 0)
            .Sum(item => item?.TotalSaldoTipo) ?? 0;
        public decimal TotalRecebidoGeral => TiposReceita?
            .Where(item => item.TotalRecebidoTipo != 0)
            .Sum(item => item?.TotalRecebidoTipo) ?? 0;
        public int TotalParcelasGeral => TiposReceita?
            .Where(item => item.TotalParcelas != 0)
            .Sum(item => item?.TotalParcelas) ?? 0;
    }

    public class TiposReceita
    {
        public int TipoReceita { get; set; }
        public ICollection<ReceitaItens> ReceitaItens { get; set; }

        private decimal TotalRecebidoAditadoTipo => ReceitaItens?
            .Where(item => item.ValorRecebido != 0 && item.aditado == true)
            .Sum(item => item?.ValorRecebido) ?? 0;
        public decimal TotalValorTipo => ReceitaItens?
            .Where(item => item.Valor != 0 && item.aditado == false)
            .Sum(item => item?.Valor) + TotalRecebidoAditadoTipo ?? 0 + TotalRecebidoAditadoTipo;
        public decimal TotalSaldoTipo => ReceitaItens?
            .Where(item => item.Saldo != 0 && item.aditado == false)
            .Sum(item => item?.Saldo) ?? 0;
        public decimal TotalRecebidoTipo => ReceitaItens?
            .Where(item => item.ValorRecebido != 0)
            .Sum(item => item?.ValorRecebido) ?? 0;
        public int TotalParcelas => ReceitaItens?
            .Where(item => item.QuantidadeParcelas != 0)
            .Sum(item => item?.QuantidadeParcelas) ?? 0;
    }

    public class ReceitaItens
    {
        public bool aditado { get; set; }
        public int QuantidadeParcelas { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public decimal ValorRecebido { get; set; }
    }
}
