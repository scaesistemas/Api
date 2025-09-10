using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("atendimento", Schema = "geral")]

    public class Atendimento : IEntity
    {
        public int Id { get; set; }
        public int TipoAtendimentoId { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }
        public string Descricao { get; set; }
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
        public int CorretorId { get; set; }
        public Usuario Corretor { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Titulo { get; set; }
        public DateTime? DataAgendamento { get; set; }
        public DateTime? DataConclusao { get; set; }
        public bool Realizado { get; set; }

    }
}
