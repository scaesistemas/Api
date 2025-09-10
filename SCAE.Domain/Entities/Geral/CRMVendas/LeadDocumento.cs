using System.ComponentModel.DataAnnotations.Schema;
using SCAE.Domain.Interfaces.Shared;

namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("leaddocumento", Schema = "geral")]
    public class LeadDocumento : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public Lead Lead { get; set; }

        public LeadDocumento()
        {

        }

        public LeadDocumento(int id, int leadId, string nome, decimal tamanho, string tipo)
        {
            Id = id;
            LeadId = leadId;
            Nome = nome;
            Tamanho = tamanho;
            Tipo = tipo;
        }
    }
}