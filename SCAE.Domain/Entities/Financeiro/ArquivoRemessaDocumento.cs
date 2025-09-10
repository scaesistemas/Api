using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Financeiro
{
    [Table("arquivoremessadocumento", Schema = "financeiro")]
    public class ArquivoRemessaDocumento : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int RemessaId { get; set; }

        public ArquivoRemessaDocumento()
        {

        }

        public ArquivoRemessaDocumento(int id, int remessaId, string nome, decimal tamanho, string tipo) : this()
        {
            Id = id;
            RemessaId = remessaId;
            Nome = nome;
            Tamanho = tamanho;
            Tipo = tipo;
        }
    }
}
