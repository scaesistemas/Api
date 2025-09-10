using Newtonsoft.Json.Converters;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("retornobancario", Schema = "financeiro")]
    public class RetornoBancario: IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Documento { get; set; }
        public DateTime DataEmissao { get; set; }
    }
}
