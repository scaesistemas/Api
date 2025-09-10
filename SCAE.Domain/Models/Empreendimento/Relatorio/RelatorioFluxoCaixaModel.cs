using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioFluxoCaixaModel
    {

        //public ICollection<ReceitaFluxoCaixaModel> receitasEmpreendimentosFluxoCaixa { get; set; }
        public ICollection<ValorPorMesModel> ReceitaECustoMensais { get; set; }
        public decimal TotalReceitaFinal => ReceitaECustoMensais?
            .Sum(item => item.TotalReceitaMes) ?? 0;
        public decimal TotalDespesaFinal => ReceitaECustoMensais?
            .Sum(item => item.TotalDespesaMes) ?? 0;

        public decimal ReceitaxCustoFinal { get; set; }

        public RelatorioFluxoCaixaModel()
        {
            ReceitaECustoMensais = new List<ValorPorMesModel>();
        }
    }



    public class ValorPorMesModel
    {
        public string NomeMes { get; set; }
        public ICollection<ValorEmpreendimentoPorMesModel> ReceitasEmpreendimento { get; set; }
        public ICollection<ValorEmpreendimentoPorMesModel> DespesaEmpreendimento { get; set; }
        public decimal TotalReceitaMes => ReceitasEmpreendimento?
            .Sum(item => item.Valor) ?? 0;
        public decimal TotalDespesaMes => DespesaEmpreendimento?
            .Sum(item => item.Valor) ?? 0;
        public decimal ReceitaXCustoNaoCumulativo => TotalReceitaMes - TotalDespesaMes;
        public decimal ReceitaXCustoMesAnterior;
        public decimal ReceitaXCusto { get; set; }
        public ValorPorMesModel()
        {
            ReceitasEmpreendimento = new List<ValorEmpreendimentoPorMesModel>();
            DespesaEmpreendimento = new List<ValorEmpreendimentoPorMesModel>();
        }
    }

    public class ValorEmpreendimentoPorMesModel
    {
        public string EmpreendimentoNome { get; set; }
        public decimal Valor { get; set; }
    }

    public class NovoRelatorioFluxoCaixaModel 
    {
        public List<ModeloRelatorio> modeloRelatoriosReceita { get; set; } = new List<ModeloRelatorio>();
        public List<ModeloRelatorio> modeloRelatoriosDespesa { get; set; } = new List<ModeloRelatorio>();
        public List<ModeloMeses> Resultado { get; set; } = new List<ModeloMeses>();
        public List<ModeloMeses> SaldoInicial { get; set; } = new List<ModeloMeses>();
        public List<ModeloMeses> Acumulado { get; set; } = new List<ModeloMeses>();
        public decimal totalDespesa => modeloRelatoriosDespesa.Sum(x => x.total);
        public decimal totalReceita => modeloRelatoriosReceita.Sum(x => x.total);
        public decimal resultadoTotal => totalDespesa - totalReceita;

    }

    public class ModeloRelatorio
    { 
        public string Nome { get; set; }
        public List<ModeloMeses> ListamodeloMeses { get; set; } = new List<ModeloMeses>();
        public decimal total => ListamodeloMeses.Sum(x => x.valor);
    
    }
    public class ModeloMeses 
    {
        public string mes {  get; set; }
        public decimal valor { get; set; }
    }

    public class ComparadorModeloMeses : IEqualityComparer<ModeloMeses>
    {
        public bool Equals(ModeloMeses x, ModeloMeses y)
        {
            return x.mes == y.mes;
        }

        public int GetHashCode([DisallowNull] ModeloMeses obj)
        {
            return obj.mes.GetHashCode();
        }
    }

}

