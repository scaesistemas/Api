using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes
{
    [Table("historicosituacaocontrato", Schema = "clientes")]
    public class HistoricoSituacaoContrato : IEntity
    {
        public HistoricoSituacaoContrato()
        {
        } 

        public HistoricoSituacaoContrato(int situacaoId)
        {
            SituacaoId = situacaoId;
            DataAlteracao = DateTime.Now;
        }

        public HistoricoSituacaoContrato(int situacaoId, int? usuarioId, DateTime? data = null)
        {
            UsuarioId = usuarioId;
            SituacaoId = situacaoId;
            DataAlteracao = data ?? DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DataAlteracao { get; set; }
        public SituacaoContrato Situacao { get; set; }
        public int SituacaoId { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
    }
}
