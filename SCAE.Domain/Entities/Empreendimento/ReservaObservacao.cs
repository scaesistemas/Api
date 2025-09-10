using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("reservaobservacao", Schema = "empreendimento")]

    public class ReservaObservacao : IEntity
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
        public string Observacao { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }

        public ReservaObservacao()
        {
            DataCriacao = DateTime.Now;
        }

        public ReservaObservacao(int usuarioId, DateTime dataCriacao, string observacao)
        {
            UsuarioId = usuarioId;
            DataCriacao = dataCriacao;
            Observacao = observacao;
        }
    }
}
