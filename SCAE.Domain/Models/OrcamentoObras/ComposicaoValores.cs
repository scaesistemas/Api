using SCAE.Domain.Entities.OrcamentoObras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.OrcamentoObras
{
    public class ComposicaoValores
    {
        public Composicao Composicao { get; set; }
        public decimal ValorDesonerado { get; set; }
        public decimal ValorNaoDesonerado { get; set; }

    public ComposicaoValores(Composicao composicao, decimal valorDesonerado, decimal valorNaoDesonerado)
        {
            Composicao = composicao;
            ValorDesonerado = valorDesonerado;
            ValorNaoDesonerado = valorNaoDesonerado;
        }
    }
    public class ListarComposicoesValores
    {
        public List<ComposicaoValores> Items = new List<ComposicaoValores>();
        public long Count;
    }

}