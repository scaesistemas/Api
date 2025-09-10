using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("antecipacaocomprovante", Schema = "financeiro")]
    public class AntecipacaoComprovante : IEntity
    {
        private byte[] _documento;
        public int Id { get; set; }
        public bool IsQuitacao { get; set; }
        public string Protocolo { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime? DataEmissaoComprovante { get; set; }
        public DateTime DataCriacaoAntecipacao { get; set; }
        public int ReceitaParcelaId { get; set; }
        public ReceitaParcela ReceitaParcela { get; set;}
        public Encargo EncargoContrato { get; set; }

        public byte[] Documento { get { return null; } set { _documento = value; } }

        public byte[] GetDocumento()
        {
            return _documento;
        }

    }
}
