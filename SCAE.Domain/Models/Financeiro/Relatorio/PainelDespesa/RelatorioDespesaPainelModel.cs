using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SCAE.Domain.Models.Financeiro.Relatorio.PainelDespesa;

public class RelatorioDespesaPainelModel
{

    public DespesaRelatorioModel DespesaRelatorio { get; set; }

    public List<DemonstrativoResultadoModel> ListaCentroCustoModel { get; set; } = new List<DemonstrativoResultadoModel>();


    //public decimal TotalCentroCusto => Math.Round(ListaCentroCustoModel.Sum(x => x.ValorTotal), 2);


}
public class DespesaRelatorioModel
{

    public decimal TotalPagoAno { get; set; }

    public decimal TotalPagoMes { get; set; }

    public decimal TotalPagarAno { get; set; }


    public List<TotalPagarMesModel> ListatotalPagarMes { get; set; } = new List<TotalPagarMesModel>();
    public List<GraficoDespesa> ListaParcelaPagarDia { get; set; } = new List<GraficoDespesa>();

    public decimal Vencidos { get; set; }

    public decimal VencidosHoje { get; set; }

    //Perto da data de vencimento
    public decimal AVencer { get; set; }





}



public class TotalPagarMesModel
{

    public DateTime Data { get; set; }
    public string Mes => Data.ToString("MMMM", new CultureInfo("pt-BR")).ToUpper().Substring(0, 3);

    public decimal Valor { get; set; }

}


public class GraficoDespesa
{

    public string GrupoDias { get; set; }
    public decimal Pago { get; set; }
    public decimal APagar { get; set; }

}

//public class CentroCustoModel
//{
//    public decimal ValorTotal { get; set; }

//    public string nome { get; set; }

//    public decimal AV { get; set; }

//    public List<CentroCustoModel> CentroCustoModels { get; set; }

//    public List<TotalPagarMes> ListatotalPagarMes { get; set; } = new List<TotalPagarMes>();


//}
public class PainelDespesaAPagarMesModel
{
    public string NomeCategoria { get; set; }
    public decimal ValorTotalPago { get; set; }
    public decimal ValorTotalAPagar {  get; set; }
}
public class PainelDemonstrativoGeralModel
{
    public decimal ValorTotalPago => Demonstrativos.Where(x=>x.DemonstrativoPaiId == null).Sum(x=>x.ValorTotalPago);

    public decimal ValorTotalAPagar => Demonstrativos.Where(x => x.DemonstrativoPaiId == null).Sum(x => x.ValorTotalAPagar);
    public decimal ValorTotal => ValorTotalAPagar + ValorTotalPago;
    public List<DemonstrativoResultadoModel> Demonstrativos { get; set; } = new List<DemonstrativoResultadoModel>();
    public List<DemonstrativoMesModel> DemonstrativoMesTotais { get; set; } = new List<DemonstrativoMesModel>();

}

/// <summary>
/// Pode ser um centro de custo ou conta gerencial
/// </summary>
public class DemonstrativoResultadoModel
{

    public string Nome { get; set; }

    public decimal AV { get; set; }
    public int DemonstrativoId { get; set; }
    public int? DemonstrativoPaiId { get; set; }
    public decimal ValorTotalPago => DemonstrativoMesModel?.Sum(x => x.PagoComFilhos) ?? 0; /*+ CentroCustoChildren?.Sum(x => x.ValorTotalPago) ?? 0;*/

    public decimal ValorTotalAPagar => DemonstrativoMesModel?.Sum(x => x.APagarComFilhos) ?? 0; /*+ CentroCustoChildren?.Sum(x => x.ValorTotalAPagar) ?? 0;*/

    public decimal ValorTotal => ValorTotalAPagar + ValorTotalPago;
    public List<DemonstrativoMesModel> DemonstrativoMesModel { get; set; } = new List<DemonstrativoMesModel>();

    public List<DemonstrativoResultadoModel> CentroCustoChildren { get; set; }

}

public class DemonstrativoMesModel
{
    public DateTime Data { get; set; }
    public string Mes => Data.ToString("MMMM", new CultureInfo("pt-BR")).ToUpper().Substring(0, 3);
    public decimal Pago { get; set; }
    public decimal APagar { get; set; }
    public decimal ValorTotal => Math.Round(Pago + APagar, 2);

    ///
    public decimal PagoComFilhos { get; set; }
    public decimal APagarComFilhos { get; set; }
    public decimal ValorTotalComFilhos => Math.Round(PagoComFilhos + APagarComFilhos, 2);

}