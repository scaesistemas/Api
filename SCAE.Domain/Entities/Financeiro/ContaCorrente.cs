using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("contacorrente", Schema = "financeiro")]
    public class ContaCorrente : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [Required] public string Nome { get; set; }
        [Required] public bool GeraBoleto { get; set; }
        [Required] public int BancoId { get; set; }
        public Banco Banco { get; set; }
        [StringLength(5)] public string NumeroAgencia { get; set; }
        [StringLength(2)] public string DigitoAgencia { get; set; }
        public string AgenciaNumeroDigito => $"{NumeroAgencia}-{DigitoAgencia}";
        [StringLength(10)] public string NumeroConta { get; set; }
        [StringLength(2)] public string DigitoConta { get; set; }
        public string ContaNumeroDigito => $"{NumeroConta}-{DigitoConta}";
        [StringLength(10)] public string CodigoCedente { get; set; } //código beneficiário
        [StringLength(1)] public string DigitoCedente { get; set; }
        [StringLength(5)] public string Carteira { get; set; }
        [StringLength(5)] public string DigitoCarteira { get; set; }

        //QrCode Santander
        public string KeyTypeDict {  get; set; }
        public string KeyDictKey { get; set; }
        public string TxIdSantander {  get; set; }

        //QrCode Siccob
        public bool GerarBoletoComPix { get; set; }

        public decimal SaldoInicial { get; set; }
        public decimal Saldo { get; set; }

        [StringLength(4)] public string ClienteDesde { get; set; }
        public long BoletoSequencia { get; set; }
        public int RemessaSequencia { get; set; }
        public Encargo EncargoFinanceiro { get; set; }
        [StringLength(60)] public string Instrucao1 { get; set; }
        [StringLength(60)] public string Instrucao2 { get; set; }
        [StringLength(60)] public string Instrucao3 { get; set; }
        public bool IsPoupanca { get; set; }
        public bool GerarInstrucoes { get; set; }
        [MaxLength(45)] public string CodigoZoop { get; set; }
        [MaxLength(45)] public string CodigoTokenZoop { get; set; }
        [MaxLength(45)] public string CodigoAssociacaoZoop { get; set; }

        #region Certificado digital
        public string NomeCertificado { get; set; }
        public string SenhaCertificado { get; set; }
        public DateTime? DataUploadCertificado { get; set; }
        #endregion


        #region Para integração com bancos
        public string ClientId { get; set; }
        public string ClientSecret { get; set; } // é o password das integrações (também chamado de código de acesso)
        public string TokenAcesso { get; set; } 
        public string Posto { get; set; }
        public string CodWorkerSpace { get; set; } // Código criado para integração Santander
        #endregion

        public ICollection<ContaCorrenteGateway> Gateways { get; set; }
        public List<CertificadoBanco> Certificados { get; set; }

        public ContaCorrente()
        {
            IsPoupanca = false;
            GerarInstrucoes = true;
            EncargoFinanceiro = new Encargo();
            Gateways = new List<ContaCorrenteGateway>();
            Certificados = new List<CertificadoBanco>();
        }

    }
}
