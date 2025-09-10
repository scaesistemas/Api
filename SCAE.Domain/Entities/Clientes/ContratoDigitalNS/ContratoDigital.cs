using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Clientes.ContratoDigitalNS
{
    [Table("contratodigital", Schema = "clientes")]
    public class ContratoDigital : IEntity
    {

        public int Id { get ; set; }
        public string Nome { get; set; }
        public int TipoId { get; set; }
        public TipoContratoDigital Tipo { get; set; }
        public string ConteudoEditavel { get; set; }
        public ContratoDigitalDocumento Documento { get; set; }
        public int SituacaoId { get; set; }
        public SituacaoContratoDigital Situacao { get; set; }
        public string DFourSignDocumentId { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public DateTime? DataUploadDocumento { get; set; }
        public DateTime? DataEnvioAssinatura { get; set; }
        public DateTime? DataFinalizado { get; set; }
        public DateTime? DataCancelado { get; set; } 
        public DateTime DataEmissao { get; set; }


        public ICollection<SignatarioContratoDigital> Signatarios { get; set; }

        public ContratoDigital()
        {
            Signatarios = new List<SignatarioContratoDigital>();
        }
    }
}
