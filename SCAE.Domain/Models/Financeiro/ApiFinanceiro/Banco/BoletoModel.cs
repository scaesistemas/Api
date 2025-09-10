using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco
{
    public class BoletoModel : BoletoBaseModel
    {
        public int NumeroContrato { get; set; }
        public string ContaCorrente { get; set; }
        public string Agencia { get; set; }
        public string Carteira { get; set; }
        public string? WorkerSpaceSantander { get; set; }
        public List<CertificadoBanco>? Certificados {  get; set; }


    }
}
