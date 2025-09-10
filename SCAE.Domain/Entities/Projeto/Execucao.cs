using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("Execucao", Schema = "projeto")]
     public class Execucao : IEntity
    {
        public int Id { get; set; }
        public int ContratoItemId { get; set; }
        public ContratoFornecedorItem ContratoItem { get; set; }
        public int MedicaoId { get; set; }
        public Medicao Medicao { get; set; }
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Total => ValorUnitario * Quantidade;
        public int ResponsavelId { get; set; }
        public Usuario Responsavel { get; set; }
        public string Observacao { get; set; }
        public ICollection<ExecucaoUnidade> Unidades { get; set; }
        public ICollection<ExecucaoDocumento> Documentos { get; set; }

        public Execucao()
        {
            Unidades = new List<ExecucaoUnidade>();
            Documentos = new List<ExecucaoDocumento>();
            Data = DateTime.Now;
        }
    }
}
