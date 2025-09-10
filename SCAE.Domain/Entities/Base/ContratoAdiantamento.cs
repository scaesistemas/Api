using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Base
{
    [Table("contratoadiantamento", Schema = "base")]
    public class ContratoAdiantamento : IEntity
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public int AdiantamentoCarteiraId { get; set; }
        public AdiantamentoCarteira AdiantamentoCarteira { get; set; }
        public int NumContrato { get; set; }
        public int TotalParcelas { get; set; }
        public int ParcelasPagas { get; set; }
        public Decimal ValorParcela { get; set; }
        public Decimal SaldoContrato { get; set; }
        public int ParcelasVencer { get; set; }
        public Decimal ValorTotalParcela { get; set; }
        public string NumeroSequencia { get; set; }
        public List<ParcelaAdiantamento> ContratoAdiantamentoParcelas { get; set; }

        public ContratoAdiantamento()
        {
            ContratoAdiantamentoParcelas = new List<ParcelaAdiantamento>();
        }
    }

    [Table("parcelaadiantamento", Schema = "base")]
    public class ParcelaAdiantamento
    {
        public int Id { get; set; }
        [NotMapped] public int ContratoId { get; set; }
        public int ContratoAdiantamentoId { get; set; }
        public ContratoAdiantamento ContratoAdiantamento { get; set; }
        public int ParcelaId { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorPercentualSplit { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool isColchao { get; set; }
    }
    
    public class ContratoDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string NumeroSequencia { get; set; }
        public int QuantidadeParcela { get; set; }
        public int QuantidadeParcelasPagasFinanciamento { get; set; }
        public List<ReceitaDto> Receitas { get; set; }
    }

    public class ReceitaDto
    {
        public int TipoId { get; set; }
        public int QuantidadeParcelaRestante { get; set; }
        public List<ParcelaDto> Parcelas { get; set; }
    }

    public class ParcelaDto
    {
        public int Id { get; set; }
        public int Parcela { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public int SituacaoId { get; set; }
    }
}
