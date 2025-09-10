using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("Medicao", Schema = "projeto")]
    public class Medicao : IEntity
    {
        public int Id { get; set; }
        public int ContratoFornecedorId { get; set; }
        public ContratoFornecedor ContratoFornecedor { get; set; }
        public int? DespesaId { get; set; }
        public Despesa Despesa { get; set; }
        public DateTime Data { get; set; }
        public ICollection<Execucao> Execucoes { get; set; }
        public Medicao()
        {
            Execucoes = new List<Execucao>();
        }
    }
}
