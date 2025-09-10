using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("ContratoFornecedorDocumento", Schema = "projeto")]
    public class ContratoFornecedorDocumento : Arquivo , IEntity
    {
        public int Id { get; set; }
        public int ContratoFornecedorId { get; set; }
        public ContratoFornecedor ContratoFornecedor { get; set; }
        public string Descricao { get; set; }
    }
}
