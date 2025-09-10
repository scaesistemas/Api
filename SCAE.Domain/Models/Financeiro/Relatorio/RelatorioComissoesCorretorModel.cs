using System;
using System.Collections.Generic;
using System.Linq;

namespace SCAE.Domain.Models.Financeiro.Relatorio;

public class RelatorioComissoesCorretorModel
{
    public ResumoComissaoModel ResumoComissao { get; set; }
    public ComissaoMesAMesModel ComissaoMesAMes { get; set; }
    public ExtratoComissaoModel ExtratoComissao { get; set; }

    public RelatorioComissoesCorretorModel ()
    {
        ComissaoMesAMes = new ComissaoMesAMesModel ();
        ExtratoComissao = new ExtratoComissaoModel();
        ResumoComissao = new ResumoComissaoModel();
    }
}

public class ResumoComissaoModel
{
    public int TotalVendas { get; set; }
    public decimal ValorRecebido { get; set; }
    public decimal ValorAReceber { get; set; }
    public decimal TotalComissao { get; set; }

    public ResumoComissaoModel()
    {

    }
}

public class ComissaoMesAMesModel
{
    public List<MesComissaoMesAMesModel> Meses { get; set; }
    public int TotalGeralVendas => Meses?.Sum(x => x.TotalVendas) ?? 0;
    public decimal ValorTotalRecebido => Meses?.Sum(x => x.ValorRecebido) ?? 0;
    public decimal ValorTotalAReceber => Meses?.Sum(x => x.ValorAReceber) ?? 0;
    public decimal TotalGeralComissao => Meses?.Sum(x => x.TotalComissao) ?? 0;

    public ComissaoMesAMesModel() 
    {
        Meses = new List<MesComissaoMesAMesModel>();
    }   

}
public class MesComissaoMesAMesModel
{
    public string MesNome { get; set; }
    public int TotalVendas { get; set; }
    public decimal ValorRecebido { get; set; }
    public decimal ValorAReceber { get; set; }
    public decimal TotalComissao => ValorAReceber + ValorRecebido;

}

public class ExtratoComissaoModel
{
    public ExtratoComissaoModel()
    {
        Parcelas = new List<ParcelaExtratoComissaoModel>();
    }

    public List<ParcelaExtratoComissaoModel> Parcelas { get; set; }
    public int TotalParcelas => Parcelas?.Count ?? 0;
    public decimal ValorTotalAReceber => Parcelas?.Sum(x=>x.ValorReceber) ?? 0;
    public decimal ValorTotalRecebido => Parcelas?.Sum(x => x.ValorPago) ?? 0;

}

public class ParcelaExtratoComissaoModel
{
    public DateTime DataContrato { get; set; }
    public int ContratoNumero { get; set; }
    public int ContratoSequencia { get; set; }
    public string ClienteNome { get; set; }
    public int NumeroParcela { get; set; }
    public int TotalParcelas { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime? DataPagamento { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal ValorPago { get; set; }
    public decimal ValorReceber => ValorTotal - ValorPago;

    public string ContratoNumeroSequencia => $"{ContratoNumero}-{ContratoSequencia}";
}

