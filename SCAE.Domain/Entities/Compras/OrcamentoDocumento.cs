using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Compras
{
    [Table("orcamentodocumento", Schema = "compras")]
    public class OrcamentoDocumento : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }

        public OrcamentoDocumento()
        {

        }

        public OrcamentoDocumento(int id, int orcamentoId, string nome, decimal tamanho, string tipo) : this()
        {
            Id = id;
            OrcamentoId = orcamentoId;
            Nome = nome;
            Tamanho = tamanho;
            Tipo = tipo;
        }
    }
}
