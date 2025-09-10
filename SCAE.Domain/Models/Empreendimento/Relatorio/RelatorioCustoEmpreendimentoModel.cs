using SCAE.Domain.Entities.Projeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioCustoEmpreendimentoModel
    {
        public string EmpreendimentoNome { get; set; }
        public CustoFinanceiro Financeiro { get; set; }
        public CustoEtapas Etapas { get; set; }


        public decimal TotalFinal => Financeiro?.TotalFinanceiroPago + Etapas?.TotalEtapasGeral ?? 0;

    }

    public class CustoEtapas
    {
        public ICollection<CustoEtapaItem> EtapaItems { get; set; }
        public decimal TotalProdutosGeral => EtapaItems?
            .Where(item => item.TotalProduto != 0 && item.NivelHierarquico == 0)
            .Sum(item => item?.TotalProduto) ?? 0;
        public decimal TotalServicosGeral => EtapaItems?
            .Where(item => item.TotalServiço != 0 && item.NivelHierarquico == 0)
            .Sum(item => item?.TotalServiço) ?? 0;
        public decimal TotalEtapasGeral => EtapaItems?
            .Where(item => item.TotalEtapa != 0 && item.NivelHierarquico == 0)
            .Sum(item => item?.TotalEtapa) ?? 0;
    }

    public class CustoFinanceiro
    {
        public ICollection<CustoFinanceiroItem> FinanceiroItems { get; set; }
        public decimal TotalFinanceiroDespesa => FinanceiroItems?.Sum(item => item.valorDespesa) ?? 0;
        public decimal TotalFinanceiroPago => FinanceiroItems?.Sum(item => item.valorPago) ?? 0;
    }

    public class CustoFinanceiroItem
    {
        public string numeroDocumento { get; set; }
        public decimal valorDespesa { get; set; }
        public decimal valorPago { get; set; }
    }

    public class CustoEtapaItem
    {
        public string Codigo { get; set; }
        public string CodigoEtapaPai { get; set; }
        public int NivelHierarquico { get; set; }
        public CustoEtapaItem itemEtapaPai { get; set; }

        public string NomeEtapa { get; set; }
        public int EtapaId { get; set; }
        public decimal TotalProduto { get; set; }
        public decimal TotalServiço { get; set; }
        public decimal TotalEtapa => TotalProduto + TotalServiço;
    }
}
