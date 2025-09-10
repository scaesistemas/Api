using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro
{
    public class ComprovantePagamentoModel
    {
        public Empresa Empresa { get; set; }
        public byte[] EmpresaLogo { get; set; }
        public ReceitaBaixaComprovante ReceitaBaixaComprovante { get; set; }
        public string UsuarioNome { get; set; }
        public string ClienteNome { get; set; }
        public string ContratoNumeroESequencia { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string UnidadeNome { get; set; }
        public string GrupoNome { get; set; }
        public DateTime DataVencimetoParcela { get; set; }
        public DateTime DataPagamentoBaixa { get; set; }
        public int NumeroParcela { get; set; }
        public int TotalParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Descontos { get; set; }
        public decimal Correcao { get; set; }
        public decimal Saldo { get; set; }
        public decimal ValorPagoHoje { get; set; }
       // public decimal RestaPagar { get; set; }
        public string CodigoRodape { get; set; }

        public string FormaPagamentoNome { get; set; }


    }
}
