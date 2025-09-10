using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("unidadefoto", Schema = "empreendimento")]
    public class UnidadeFoto : Arquivo, IEntity
    {
        public int Id { get; set; }
        public Unidade Unidade { get; set; }
        public int UnidadeId { get; set; }
        public string Descricao { get; set; }

        public UnidadeFoto(int id, int unidadeId, string descricao, string nome, decimal tamanho, string tipo)
        {
            Id = id;
            UnidadeId = unidadeId;
            Descricao = descricao;
            Nome = nome;
            Tamanho = tamanho;
            Tipo = tipo;
        }
    }
}
