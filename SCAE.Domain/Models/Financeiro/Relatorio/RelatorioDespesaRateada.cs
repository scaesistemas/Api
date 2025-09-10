using System;
using System.Collections.Generic;
using System.Linq;

namespace SCAE.Domain.Models.Financeiro.Relatorio;

public class RelatorioDespesaRateadaModel
{
    

    public List<ParcelaDespesaDetalhadaModel> Parcelas { get; set; }

    public List<DespesaRateadaClassificacaoModel> Classificacoes { get; set; }

    public decimal ClassificacoesTotal => Math.Round(Classificacoes.Sum(c => c.Valor),2);
    public decimal ValorTotal { get; set; }
    public decimal ValorPagoTotal { get; set; }
    public int QuantidadeParcelasTotal { get; set; }

    public RelatorioDespesaRateadaModel()
    {
        Parcelas = new List<ParcelaDespesaDetalhadaModel>();

        Classificacoes = new List<DespesaRateadaClassificacaoModel>();
    }
}


