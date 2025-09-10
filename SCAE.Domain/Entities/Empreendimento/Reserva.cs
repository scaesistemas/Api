using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("reserva", Schema = "empreendimento")]
    public class Reserva : IEntity
    {
        public int Id { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
        public int? LeadId { get; set; }
        public Lead Lead { get; set; }
        public int? CorretorId { get; set; } 
        public Usuario Corretor { get; set; }
        public int TipoReservaId { get; set; }
        public TipoReserva TipoReserva { get; set; }
        public int SituacaoId { get; set; }
        public SituacaoReserva Situacao { get; set; }
        public ICollection<ReservaObservacao> Observacoes { get; set; }
        public string Descricao { get; set; }
        public int? MotivoCancelamentoReservaId { get; set; }
        public MotivoCancelamentoReserva MotivoCancelamentoReserva { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public DateTime? DataCadastroPreReserva { get; set; }
        public DateTime? DataCadastroReserva { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public DateTime? DataEnvioAprovacao { get; set; }
        public DateTime? DataVenda { get; set; }

        public int? ContratoId { get; set; }
        public Contrato Contrato { get; set; }

        public int PosicaoFunil { get; set; }
        public int? ColunaFunilId { get; set; }
        public ColunaFunil ColunaFunil { get; set; }

        public int DiasReservados => (DateTime.Now - DataCriacao).Days;
        public int DiasCancelados => DataCancelamento.HasValue ?  (DateTime.Now - DataCancelamento.Value).Days : 0;


        public Reserva()
        {
            DataCriacao = DateTime.Now;
            Observacoes = new List<ReservaObservacao>();
        }
    }
}
