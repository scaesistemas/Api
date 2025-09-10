using SCAE.Domain.Entities.Financeiro;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco
{
    public class CertificadoRequest
    {
        public List<CertificadoBanco> Certificados { get; set; }
    }
}
