using Newtonsoft.Json;
using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco
{
    public class BaixaModel
    {
        public string CodigoBeneficiario { get; set; } = "";
        public string Agencia { get; set; } = "";
        public string NumeroConta { get; set; } = "";
        public string Carteira { get; set; } = "";
        public string NossoNumero { get; set; }
        public int NumeroContrato { get; set; } //é o contaCorrente.CodigoCedente da SCAE API
        public string CpfCnpjBeneficiario { get; set; } = ""; //Requisito do Bradesco
        public List<CertificadoBanco> Certificados {  get; set; }

    }

    public class BaixaRetornoModel
    {
        [JsonProperty("transactionId")] public string TransacaoId { get; set; }
        public string CodigoBeneficiario { get; set; }
        public string Cooperativa { get; set; }
        public string NossoNumero { get; set; }
        public DateTime DataHoraRegistro { get; set; }
        public string StatusComando { get; set; }
        public string TipoMensagem { get; set; }
    }
}
