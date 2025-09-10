using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Clientes.ContratoDigitalNS
{
    [Table("signatariocontratodigital", Schema = "clientes")]
    public class SignatarioContratoDigital : IEntity
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public Pessoa Cliente { get; set; }
        public string Email { get; set; }
        public int ContratoDigitalId { get; set; }
        public ContratoDigital ContratoDigital { get; set; }
        public int SituacaoId { get; set; }
        public SituacaoEmailSignatario Situacao { get; set; }
        public int TipoAssinaturaId { get; set; }
        public TipoAssinatura TipoAssinatura { get; set; }
        public string DFourSignKeySigner { get; set; }
        public DateTime? DataRegistroDFourSign { get; set; }
        public DateTime? DataAssinaturaDocumento { get; set; }
    }
}
