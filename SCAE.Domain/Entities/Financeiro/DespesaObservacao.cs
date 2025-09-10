using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Financeiro
{
    [Table("despesaobservacao", Schema = "financeiro")]
    public class DespesaObservacao : IEntity
    {
        public int Id { get; set; }
        public int DespesaId { get; set; }
        public Despesa Despesa { get; set; }
        public string Observacao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataHora { get; set; }
        public bool Ativo { get; set; }

        public DespesaObservacao()
        {
            DataHora = DateTime.Now;
        }

        public DespesaObservacao(int usuarioId, DateTime dataHora, string observacao)
        {
            UsuarioId = usuarioId;
            DataHora = dataHora;
            Observacao = observacao;
        }
    }
}
