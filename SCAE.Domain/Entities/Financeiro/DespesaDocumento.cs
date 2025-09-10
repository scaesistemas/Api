using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("despesadocumento", Schema = "financeiro")]
    public class DespesaDocumento : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int DespesaId { get; set; }

        public DespesaDocumento()
        {

        }

        public DespesaDocumento(int id, int despesaId, string nome, decimal tamanho, string tipo) : this()
        {
            Id = id;
            DespesaId = despesaId;
            Nome = nome;
            Tamanho = tamanho;
            Tipo = tipo;
        }
    }
}
