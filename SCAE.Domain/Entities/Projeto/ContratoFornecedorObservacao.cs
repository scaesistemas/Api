using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("ContratoFornecedorObservacao", Schema = "projeto")]
    public class ContratoFornecedorObservacao : IEntity
    {
        public int Id { get; set; }
        public int ContratoFornecedorId { get; set; }
        public ContratoFornecedor ContratoFornecedor { get; set; }
        public string Observacao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataHora { get; private set; }

        public ContratoFornecedorObservacao()
        {
            DataHora = DateTime.Now;
        }

    }
}
