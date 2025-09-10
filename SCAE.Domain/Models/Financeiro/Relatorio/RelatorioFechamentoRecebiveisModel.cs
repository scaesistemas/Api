using System.Collections.Generic;
using System.Linq;

namespace SCAE.Domain.Models.Financeiro.Relatorio
{
    public class RelatorioFechamentoRecebiveisModel
    {
        public List<TipoReceitaFechamentoModel> ReceitasFechamentoModel { get; set; }

        public int QuantidadeParcelas => ReceitasFechamentoModel.Sum(x => x.QuantidadeParcelas);
        public decimal ValorTotal => ReceitasFechamentoModel.Sum(x => x.ValorTotal);

        public List<KPIQuantidadesModel> QuantidadeParcelasSituacaoContrato { get; set; }

        public List<KPIQuantidadesModel> QuantidadeParcelasTipoAditamento { get; set; }
        public int TotalParcelasAditamento => QuantidadeParcelasTipoAditamento.Sum(x => x.Quantidade);
        public RelatorioFechamentoRecebiveisModel()
        {
            ReceitasFechamentoModel = new List<TipoReceitaFechamentoModel>();
            QuantidadeParcelasSituacaoContrato = new List<KPIQuantidadesModel>();
            QuantidadeParcelasTipoAditamento = new List<KPIQuantidadesModel>();
        }

    }

    public class TipoReceitaFechamentoModel
    {
        public string TipoReceitaNome { get; set; }
        public List<ParcelaReceitaDetalhadaModel> ParcelasReceitaDetalhadaModel { get; set; }
        public int QuantidadeParcelas => ParcelasReceitaDetalhadaModel.Count;
        public decimal ValorTotal => ParcelasReceitaDetalhadaModel.Sum(x => x.ValorPagoParcela);

        public TipoReceitaFechamentoModel()
        {
            ParcelasReceitaDetalhadaModel = new List<ParcelaReceitaDetalhadaModel>();
        }

    }



}
