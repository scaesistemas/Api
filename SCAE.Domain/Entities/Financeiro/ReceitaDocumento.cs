using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("receitadocumento", Schema = "financeiro")]
    public class ReceitaDocumento : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int ReceitaId { get; set; }

        public ReceitaDocumento()
        {

        }

        public ReceitaDocumento(int id, int receitaId, string nome, decimal tamanho, string tipo) : this()
        {
            Id = id;
            ReceitaId = receitaId;
            Nome = nome;
            Tamanho = tamanho;
            Tipo = tipo;
        }
    }
}
