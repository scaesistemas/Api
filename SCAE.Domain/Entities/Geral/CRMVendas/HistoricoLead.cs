using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("historicolead", Schema = "geral")]
    public class HistoricoLead : IEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
        public int? ColunaFunilId { get; set; }
        public ColunaFunil ColunaFunil { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public HistoricoLead() { }

        public HistoricoLead(string descricao, int usuarioId, DateTime data, int? colunaFunilId = null, int leadId = 0)
        {
            Descricao = descricao;
            Data = data;
            LeadId = leadId;
            ColunaFunilId = colunaFunilId;
            UsuarioId = usuarioId;
        }

        public HistoricoLead(string descricao,int usuarioId, int? colunaFunilId = null, int leadId = 0)
        {
            Descricao = descricao;
            LeadId = leadId;
            ColunaFunilId = colunaFunilId;
            UsuarioId = usuarioId;
            Data = DateTime.Now;
        }
    }
}
