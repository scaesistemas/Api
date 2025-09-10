using System;


namespace SCAE.Domain.Models.Financeiro.Relatorio
{
    public class RelatorioContratosEmAtrasoModel
    {
        //Contrato
        public int ContratoNumero { get; set; }
        public int QuantidadeParcelasVencidas { get; set; }
        public decimal MesesParcelaMaisAtrasada { get; set; }
        public decimal ValorParcelaMaisAtrasada { get; set; }
        public DateTime? DataParcelaMaisAtrasada { get; set; }
        public int DiasParcelaMaisAtrasada { get; set; }
        public int QuantidadeParcelasParaQuitacao { get; set; }
        public decimal ValorDebitoVencido { get; set; }
        public decimal ValorDebitoReceitaContrato { get; set; }
        public string SituacaoContrato { get; set; }


        //Empreendimento
        public string EmpresaNome { get; set; }
        public string EmpreendimentoNome { get; set; } 
        public string Quadra { get; set; }
        public string Lote { get; set; }

        //Cliente
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public string EmailCliente { get; set; }


        public decimal JurosTotal { get; set; }

        public decimal MultaTotal { get; set; }

    }
}
