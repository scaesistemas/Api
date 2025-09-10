using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("ContratoFornecedorItem", Schema = "projeto")]
    public class ContratoFornecedorItem: IEntity
    {
        public int Id { get; set; }
        public int EtapaId { get; set; }
        public Etapa Etapa { get; set; }
        public int ContratoFornecedorId{ get; set; }
        public ContratoFornecedor ContratoFornecedor{ get; set; }
        [Required] public decimal ValorUnitario{ get; set; }
        [Required] public decimal Quantidade { get; set; }
        public decimal Caucao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime  DataFim { get; set; }
        public decimal ValorTotal => ValorUnitario * Quantidade;

    }
}
