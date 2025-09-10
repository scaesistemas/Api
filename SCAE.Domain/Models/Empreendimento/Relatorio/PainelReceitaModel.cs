using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class PainelReceitaModel
    {
        public PrimeiroTotalParcelaModel PrimeiroTotalParcela { get; set; }
        public TiposRecebidosModel TiposRecebidosModel { get; set; }
        public TipoParcelasPagas TipoParcelasPagas { get; set; }
        public TiposAditamentos TiposAditamentos { get; set; }
        public List<GraficoReceita> ListaParcelaPagarDia { get; set; }
        public string MesAtual { get; set; }
    }

    public class PrimeiroTotalParcelaModel
    {
        public decimal TotalReceita { get; set; }
        public int? ParcelasRecebidas { get; set; }
        public int? ParcelasAditadas { get; set; }
    }

    public class TiposAditamentos
    {
        public int AcordoSimples { get; set; }
        public int AcordoPossuidor { get; set; }
        public int AcordoTransferencia { get; set; }
        public int AcordoJudicial { get; set; }
        public int AcordoMediacao { get; set; }
    }


    public class TiposRecebidosModel
    {
        public RecebidoInfo RecebidoAtrasado { get; set; }
        public RecebidoInfo RecebidoEmDia { get; set; }
        public RecebidoInfo RecebidoAdiantado { get; set; }

        public TiposRecebidosModel()
        {
            RecebidoAtrasado = new RecebidoInfo();
            RecebidoEmDia = new RecebidoInfo();
            RecebidoAdiantado = new RecebidoInfo();
        }
    }

    public class RecebidoInfo
    {
        public decimal TotalRecebido { get; set; }
        public int QuantidadeParcela { get; set; }
    }

    public class TipoParcelasPagas
    {
        public ParcelasInfo Financiamento { get; set; }
        public ParcelasInfo Entrada { get; set; }
        public ParcelasInfo Serviços { get; set; }
        public ParcelasInfo Aditamento { get; set; }

         public ParcelasInfo Intermediaria { get; set; }

        public TipoParcelasPagas()
        {
            Financiamento = new ParcelasInfo();
            Entrada = new ParcelasInfo();
            Serviços = new ParcelasInfo();
            Aditamento = new ParcelasInfo();
            Intermediaria = new ParcelasInfo();
        }
    }
    public class ParcelasInfo
    {
        public string Nome { get; set; }
        public decimal TotalRecebido { get; set; }
        public int QuantidadeParcela { get; set; }
        public decimal TotalReceber { get; set; }
        public int QuantidadeParcelaReceber { get; set; }
        public decimal MediaParcelas
        {
            get
            {
                return QuantidadeParcela > 0 ? (TotalRecebido + TotalReceber) / (QuantidadeParcela + QuantidadeParcelaReceber) : 0;
            }
        }
    }

    public class GraficoReceita
    {
        public string GrupoDias { get; set; }
        public decimal Receber { get; set; }
        public decimal Recebido { get; set; }
    }
}
