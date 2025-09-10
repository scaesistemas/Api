using System.Collections.Generic;
using System.Linq;

namespace SCAE.Api.Models.Financeiro
{
    public class RelatorioFluxoCaixaModel
    {
        public List<RelatorioFluxoCaixaModelItem> Itens { get; set; }

        public decimal TotalReceita => Itens.Where(x => x.Tipo == "R").Sum(x => x.Valor);
        public decimal TotalDespesa => Itens.Where(x => x.Tipo == "D").Sum(x => x.Valor);
        public decimal TotalResultado => TotalReceita - TotalDespesa;

        public decimal TotalPagoReceita => Itens.Where(x => x.Tipo == "R").Sum(x => x.ValorPago);
        public decimal TotalPagoDespesa => Itens.Where(x => x.Tipo == "D").Sum(x => x.ValorPago);
        public decimal TotalPagoResultado => TotalPagoReceita - TotalPagoDespesa;

        public RelatorioFluxoCaixaModel()
        {
            Itens = new List<RelatorioFluxoCaixaModelItem>();
        }
    }

    public class RelatorioFluxoCaixaModelItem
    {
        private decimal _valor;
        private decimal _valorPago;

        public int CentroCustoId { get; set; }
        public string CentroCusto { get; set; }
        public int ContaGerencialId { get; set; }
        public string CodigoContaGerencial { get; set; }
        public string ContaGerencial { get; set; }
        public int ParentId { get; set; }
        public string Tipo { get; set; }
        public bool TemFilho => Childrens.Any();
        public decimal Valor
        {
            get => _valor + Total;
            set => _valor = value;
        }
        public decimal ValorPago
        {
            get => _valorPago + TotalPago;
            set => _valorPago = value;
        }

        public List<RelatorioFluxoCaixaModelItem> Childrens { get; set; }
        public decimal Total => Childrens.Sum(x => x.Valor);
        public decimal TotalPago => Childrens.Sum(x => x.ValorPago);

        public override string ToString()
        {
            return $"{CodigoContaGerencial} - {Tipo} - Valor: {Valor:N2} - Total: {Total:N2}";
        }
        public RelatorioFluxoCaixaModelItem()
        {
            Childrens = new List<RelatorioFluxoCaixaModelItem>();
        }
    }
}
