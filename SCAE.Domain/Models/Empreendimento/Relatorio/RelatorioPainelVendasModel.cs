using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;

namespace SCAE.Domain.Models.Empreendimento.Relatorio;

public class RelatorioPainelVendasModel
{
    public LotesVendidosPainelVendasModel LotesVendidos { get; set; }
    public ContratosCanceladosPainelVendasModel ContratosCancelados { get; set; }
    public ContratosQuitadosPainelVendasModel ContratosQuitados { get; set; }
    public EstadoLotesPainelVendasModel EstadoLotes { get; set; }
    public VendasCorretoresPainelVendasModel VendasCorretores { get; set; }
    public RelatorioPainelVendasModel()
    {
        LotesVendidos = new LotesVendidosPainelVendasModel();
        ContratosCancelados = new ContratosCanceladosPainelVendasModel();
        ContratosQuitados = new ContratosQuitadosPainelVendasModel();
        EstadoLotes = new EstadoLotesPainelVendasModel();
        VendasCorretores = new VendasCorretoresPainelVendasModel();
    }
}

public class LotesVendidosPainelVendasModel
{
    public List<LotesVendidosPainelVendasItemsModel> Items { get; set; }
    public int TotalLotesVendidos => Items.Sum(x => x.Quantidade);

    public LotesVendidosPainelVendasModel()
    {
        Items = new List<LotesVendidosPainelVendasItemsModel>();
    }
}


public class LotesVendidosPainelVendasItemsModel
{
    public DateTime DataInteira { get; set; }
    public string Mes { get; set; }  
    public int Quantidade { get; set; }
}



public class ContratosCanceladosPainelVendasModel
{
    public List<ContratosCanceladosPainelVendasItemsModel> Items { get; set; }
    public int TotalContratosCancelados => Items.Sum(x => x.Quantidade);

    public ContratosCanceladosPainelVendasModel()
    {
        Items = new List<ContratosCanceladosPainelVendasItemsModel>();
    }
}

public class ContratosCanceladosPainelVendasItemsModel
{
    public DateTime DataInteira { get; set; }
    public string Mes { get; set; }
    public int Quantidade { get; set; }
}

public class ContratosQuitadosPainelVendasModel
{
    public List<ContratosQuitadosPainelVendasItemsModel> Items { get; set; }
    public int TotalContratosQuitados => Items.Sum(x => x.Quantidade);

    public ContratosQuitadosPainelVendasModel()
    {
        Items = new List<ContratosQuitadosPainelVendasItemsModel>();
    }
}

public class ContratosQuitadosPainelVendasItemsModel
{
    public DateTime DataInteira { get; set; }
    public string Mes { get; set; }
    public int Quantidade { get; set; }
}

public class EstadoLotesPainelVendasItemsModel
{
    public int QuantidadeDisponiveis { get; set; }
    public int QuantidadeIndisponiveis { get; set; }
    public int QuantidadeVendidos { get; set; }
    public int QuantidadeReservados { get; set; }
    public int QuantidadeInvadidos { get; set; }
    public int QuantidadePenhorados { get; set; }
}

public class EstadoLotesPainelVendasModel
{
    public EstadoLotesPainelVendasItemsModel Item { get; set; }
    public int TotalLotes =>  Item.QuantidadeVendidos + 
        Item.QuantidadeInvadidos + 
        Item.QuantidadePenhorados + 
        Item.QuantidadeReservados + 
        Item.QuantidadeDisponiveis + 
        Item.QuantidadeIndisponiveis;
}

public class VendasCorretoresPainelVendasItemsModel
{
    public string nome { get; set; }
    public int VendasRealizadas {  get; set; }
    public int VendasCanceladas { get; set; }
}

public class VendasCorretoresPainelVendasModel
{
    public List<VendasCorretoresPainelVendasItemsModel> Items { get; set; }

    public VendasCorretoresPainelVendasModel()
    {
        Items = new List<VendasCorretoresPainelVendasItemsModel>();
    }
}