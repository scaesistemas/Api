using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway
{
    public class BoletoModel : BoletoBaseModel
    {
        public string Codigo { get; set; }
        public string CodigoPagador { get; set; }
        public string CodigoBeneficiario { get; set; }
        public SplitPagamentoBoletoBase? SplitPagamento { get; set; }
    }

    public class SplitPagamentoBoletoBase
    {
        public BoletoSplitConfigBase BoletoSplitConfigBase { get; set; }
    }

    public class BoletoSplitConfigBase
    {
        public TipoSplit TipoSplit { get; set; }
        public List<EmpresaSplitConfigBase> EmpresasSplitConfigBase { get; set; }
    }

    public class EmpresaSplitConfigBase
    {
        public int GalaxPayId { get; set; }
        public int Valor {  get; set; }
    }

    public enum TipoSplit
    {
        Percentual = 0, // percent
        Fixo = 1 //fixed
    }
}