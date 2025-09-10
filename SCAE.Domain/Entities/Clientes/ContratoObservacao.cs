using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Clientes
{
    [Table("contratoobservacao", Schema = "clientes")]
    public class ContratoObservacao : IEntity
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public string Observacao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataHora { get; set; }
        public bool Ativo { get; set; }

        public ContratoObservacao()
        {
            DataHora = DateTime.Now;
        }

        public ContratoObservacao(int usuarioId, DateTime dataHora, string observacao)
        {
            UsuarioId = usuarioId;
            DataHora = dataHora;
            Observacao = observacao;
        }
    }
}
