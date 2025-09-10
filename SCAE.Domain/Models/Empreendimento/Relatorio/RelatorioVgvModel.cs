using System;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioVgvModel
    {
        public RelVgvModel VgvLotesDisponiveis { get; set; }
        public RelVgvModel VgvAReceber { get; set; }
        public RelVgvModel VgvCarteiraRecebida { get; set; }
        public RelVgvModel VgvLotesDisponiveisAReceber { get; set; }
        public RelVgvModel VgvLotesDisponiveisRecebido { get; set; }
        public RelVgvModel VgvLotesDisponiveisAReceberRecebido { get; set; }
        //public RelVgvModel VgvRecebidoAReceber { get; set; }
        public RelVgvModel VgvInadimplencia { get; set; }
        public RelVgvModel VgvAReceberInadimplencia { get; set; }
        public RelVgvModel VgvLotesDisponiveisAReceberInadimplencia { get; set; }
        public decimal ValorPresente { get; set; }
        public decimal SimulacaoValorPresente { get; set; }

        public RelatorioVgvModel()
        {
            VgvLotesDisponiveis = new RelVgvModel("Lotes Disponíveis", 0, 0, 0, 0, 0, 0, 0, 0);
            VgvAReceber = new RelVgvModel("Carteira a Receber", 0, 0, 0, 0, 0, 0, 0, 0);
            VgvCarteiraRecebida = new RelVgvModel("Carteira Recebida", 0, 0, 0, 0, 0, 0, 0, 0);
            VgvLotesDisponiveisAReceber = new RelVgvModel("Lotes Disponíveis + Carteira a Receber", 0, 0, 0, 0, 0, 0, 0, 0); 
            VgvLotesDisponiveisRecebido = new RelVgvModel("Lotes Disponíveis + Carteira Recebida", 0, 0, 0, 0, 0, 0, 0, 0);
            VgvLotesDisponiveisAReceberRecebido = new RelVgvModel("Lotes Disponíveis + Carteira a Receber + Carteira Recebida ", 0, 0, 0, 0, 0, 0, 0, 0);
            //VgvRecebidoAReceber = new RelVgvModel("Carteira a Receber + Carteira Recebida", 0, 0, 0, 0, 0, 0, 0, 0);
            VgvInadimplencia = new RelVgvModel("Inadimplência", 0, 0, 0, 0, 0, 0, 0, 0);
            VgvAReceberInadimplencia = new RelVgvModel("Carteira a Receber - Inadimplência", 0, 0, 0, 0, 0, 0, 0, 0);
            VgvLotesDisponiveisAReceberInadimplencia = new RelVgvModel("Lotes Disponíveis + Carteira a Receber - Inadimplência", 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }

    public class RelVgvModel
    {
        public string Nome { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal SimuladoValorTotal { get; set; }
        public int QuantidadeLotes { get; set; }
        public int QuantidadeParcelas { get; set; }
        public decimal ValorMedioLotes { get; set; }
        public decimal ValorMedioParcelas { get; set; }
        public decimal SimuladoValorMedioLotes { get; set; }
        public decimal SimuladoValorMedioParcelas { get; set; }
        public decimal PercentualInadimplencia { get; set; }

        public RelVgvModel(string nome, decimal valorTotal, decimal simuladoValorTotal, int quantidadeLotes, int quantidadeParcelas, decimal valorMedioLotes, decimal valorMedioParcelas, decimal simuladoValorMedioLotes, decimal simuladoValorMedioParcelas)
        {
            Nome = nome;
            ValorTotal = valorTotal;
            SimuladoValorTotal = simuladoValorTotal;
            QuantidadeLotes = quantidadeLotes;
            QuantidadeParcelas = quantidadeParcelas;
            ValorMedioLotes = valorMedioLotes;
            ValorMedioParcelas = valorMedioParcelas;
            SimuladoValorMedioLotes = simuladoValorMedioLotes;
            SimuladoValorMedioParcelas = simuladoValorMedioParcelas;
        }

        //public RelVgvModel(int quantidadeLotes, decimal valorTotal, int quantidadeParcelas, decimal valorMedioParcelas, decimal valorMedioLotes, decimal simuladoValorTotal, decimal simuladoValorMedioParcelas,  decimal simuladoValorMedioLotes,decimal? correcaoCarteira)
        //{
        //    ValorTotal = valorTotal;
        //    SimuladoValorTotal = simuladoValorTotal;
        //    QuantidadeLotes = quantidadeLotes;
        //    QuantidadeParcelas = quantidadeParcelas;
        //    ValorMedioLotes = valorMedioLotes;
        //    ValorMedioParcelas = valorMedioParcelas;
        //    SimuladoValorMedioLotes = simuladoValorMedioLotes;
        //    SimuladoValorMedioParcelas = simuladoValorMedioParcelas;

        //    if(correcaoCarteira.HasValue)
        //    {
        //        simuladoValorTotal = Math.Round((unidadesDisponiveis.Sum(x => x.ValorVenda) * correcaoCarteira.Value) / 100)
        //    }

        //}
    }
}
