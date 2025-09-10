using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway
{
    public class TransacaoRetornoModel
    {

        public BoletoModel Boleto { get; set; }
        public DateTime? DataPagamento { get; set; }
        public List<TransacaoHistoricoModel> Historicos { get; set; }

        public TransacaoRetornoModel()
        {
            Historicos = new List<TransacaoHistoricoModel>();
            Boleto = new BoletoModel();
        }
    }

    public class TransacaoHistoricoModel
    {
        public string Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Situacao { get; set; }
        public bool Pago { get; set; }

    }
}

