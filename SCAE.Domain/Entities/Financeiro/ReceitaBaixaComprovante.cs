using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("receitabaixacomprovante", Schema = "financeiro")]
    public class ReceitaBaixaComprovante : IEntity
    {
        public int Id { get; set; }
        public DateTime dataEmissao { get; set; }
        public int ReceitaBaixaId { get; set; }
        public ReceitaBaixa ReceitaBaixa { get; set; }
    }
}
