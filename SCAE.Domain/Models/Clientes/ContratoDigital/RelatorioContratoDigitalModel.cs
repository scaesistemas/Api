using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Clientes.ContratoDigital
{
    public class RelatorioContratoDigitalModel
    {
        public List<RelContratoDigitalModel> ContratosDigitais { get; set; }
        public int TotalContratosDigitais { get; set; }
        public int TotalSignatarios { get; set; }
        public RelatorioContratoDigitalModel()
        {
            ContratosDigitais = new List<RelContratoDigitalModel>();
        }
    }

    public class RelContratoDigitalModel
    {
        public int Numero { get; set; }
        public string EmpresaNome { get; set; }
        public string SituacaoNome { get; set; }
        public string Tipo { get; set; }
        public DateTime? DataEmissao { get; set; }
        public DateTime? DataEnvioAssinatura { get; set; }
        public DateTime? DataAssinatura { get; set; }
    }
}
