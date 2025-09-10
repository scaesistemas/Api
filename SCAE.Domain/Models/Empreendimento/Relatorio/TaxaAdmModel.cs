using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class TaxaAdmModel
    {
        public List<ParcelaTaxaAdmModel> Parcelas { get; set; }
        public decimal TotalValorTaxaAdm => Parcelas.Sum(x => x.ValorTaxaAdm);
        public decimal TotalValorPago => Parcelas.Sum(x => x.ValorPagoParcela);
        public decimal TotalRecebido => Parcelas.Sum(x => x.ValorRecebido);

        public TaxaAdmModel()
        {
            Parcelas = new List<ParcelaTaxaAdmModel>();
        }
    }

    public class ParcelaTaxaAdmModel
    {
        public int ContratoNumero { get; set; }
        public int SequenciaNumero { get; set; }
        public string EmpresaNome { get; set; }
        public string ClienteNome { get; set; }
        public string NumeroSequenciaContrato { get; set; }
        public string ProprietarioNome { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string GrupoNome { get; set; }
        public string UnidadeNome { get; set; }
        public int ParcelaNumero { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorPagoParcela { get; set; }
        public decimal JurosParcelaBaixa { get; set; }
        public decimal MultaParcelaBaixa { get; set; }
        public decimal DescontoParcelaBaixa { get; set; }
        public DateTime VencimentoParcela { get; set; }
        public DateTime? DataPagamentoParcela { get; set; }
      //  public decimal ValorTaxaAdm { get; set; }
     //   public decimal ValorCorretor { get; set; }
       // public decimal  ValorTaxaAdmMenosCorretor { get; set; }
        public decimal PercentualProprietario { get; set; }
        public decimal PercentualAdministradora { get; set; }
        public decimal PercentualTotalCorretor { get; set; }
        public decimal ValorTaxaAdm => (ValorPagoParcela * PercentualAdministradora) / 100;
        public decimal ValorCorretor => (ValorPagoParcela * PercentualTotalCorretor) / 100;
        public decimal ValorTaxaAdmMenosCorretor => ((ValorPagoParcela - ValorCorretor) * PercentualAdministradora) / 100;
        public decimal ValorRecebido => ((ValorPagoParcela - ValorTaxaAdmMenosCorretor - ValorCorretor) * PercentualProprietario) / 100;

    }
}
