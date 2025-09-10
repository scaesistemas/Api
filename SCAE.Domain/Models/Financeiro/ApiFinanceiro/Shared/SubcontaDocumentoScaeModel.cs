using System;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared
{
    public class SubcontaDocumentoScaeModel
    {
        public string TipoDocumento { get; set; }
        public byte[] SelfieDocumento { get; set; }
        public byte[] FotoDocumentoResponsavel { get; set; }
        public byte[] VersoDocumentoResponsavel { get; set; }
        public byte[] ContratoSocial { get; set; }
        public string SobreNos { get; set; }
        public decimal RendaMensalEmpresa { get; set; }
        public string SiteDaEmpresa { get; set; }
        public string NomeResponsavel { get; set; }
        public string CPFCNPJResponsavel { get; set; }
        public string NomeDaMae { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Type { get; set; }
    }
}