using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco;

public class RetornoConsultaModel
{
    public string LinhaDigitavel { get; set; }
    public string CodigoQrCode { get; set; }
    public RetornoConsultaLiquidacaoModel DadosLiquidacao { get; set; }
    public RetornoConsultaAdicionais RetornoConsultaAdicionais { get; set; }
}

public class RetornoConsultaLiquidacaoModel
{
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public decimal Multa { get; set; }
    public decimal Juros { get; set; }
    public decimal Desconto { get; set; }
    public decimal Abatimento { get; set; }
}

public class RetornoConsultaAdicionais
{
    public string BeneficiarioCarteira { get; set; }
    public string? DeneficiarioCarteiraDigito { get; set; }
}
