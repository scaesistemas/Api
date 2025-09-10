using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Financeiro
{
    public class ListaSimulacaoAdiantamentoCarteira
    {
        public List<ItemSimuladoAdiantamentoCarteira> Itens { get; set; } = new List<ItemSimuladoAdiantamentoCarteira>(); 
    }
    public class ItemSimuladoAdiantamentoCarteira
    {
        public int QuantidadeParcela { get;   set; }
        public decimal ValorSimulado {  get; set; }
        public string QuantidadexValor => $"{QuantidadeParcela}x  de  R$ {ValorSimulado}";
    }

    public class ValorAdiantamentoLiberado
    {
        public decimal ValorMaximo { get; set; }
        public decimal ValorMinimo { get; set; }
    }
}
