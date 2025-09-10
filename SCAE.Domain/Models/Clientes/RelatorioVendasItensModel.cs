using System;
using System.Collections.Generic;
using System.Linq;

namespace SCAE.Domain.Models.Clientes;


public class RelatorioGeralVendasModel
{
    public List<RelatorioVendasItensModel> RelatorioVendasItensModels { get; set; }

    public decimal TotaisPago => RelatorioVendasItensModels?.Sum(item => item.ValorTotalPago) ?? 0;

    public decimal TotaisAberto => RelatorioVendasItensModels?.Sum(item => item.ValorTotalAberto) ?? 0; 
     
    public int QtdeContrato => RelatorioVendasItensModels?.Count() ?? 0; 
}  
 
public class RelatorioVendasItensModel
{
    public string EmpreendimentoNome { get; set; }
    public string GrupoNome { get; set; }
    public string UnidadeNome { get; set; }

    public string ClienteNome { get; set; }
    public string ClienteCPF { get; set; }
    public string ClienteCEP { get; set; }
    public string ClienteLogradouro { get; set; }
    public string ClienteNumero { get; set; }
    public string ClienteComplemento { get; set; }
    public string ClienteBairro { get; set; }
    public string ClienteMunicipio { get; set; }
    public string ClienteUF { get; set; }
    public string ClienteEmail { get; set; }
    public string ClienteCelular { get; set; }
    public string NumeroSequenciaContrato { get; set; }
    public string SituacaoContrato { get; set; }
    public DateTime DataContrato { get; set; }
    public DateTime? DataUltimoPagamento { get; set; }

    public DateTime? DataUltimaParcela { get; set; }

    public decimal ValorTotalPago { get; set; }
    public decimal ValorTotalAberto { get; set; }
    public decimal ValorFinanciamento { get; set; }
    public decimal ValorEntrada { get; set; }
    public decimal ValorServiço { get; set; }
    public decimal ValorFinanciamentoComIntermediaria { get; set; }
    public decimal ValorContrato { get; set; }


    //novos atributos
    public string UnidadeMatricula { get; set; }

    public string UnidadeEscritura { get; set; }

    public string EmpresaNome { get; set; }

    public string UsuarioResponsavel { get; set; }    

    public DateTime? DataSituacaoAtualContrato { get; set; }

}
