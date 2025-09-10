using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral.ModuloPrefeitura
{
    [Table("pessoaprefeituradocumento", Schema = "geral")]
    public class PessoaPrefeituraDocumento : Arquivo, IEntity
    {
        public int Id { get; set; }
        public int PessoaPrefeituraId { get; set; }
        public PessoaPrefeitura PessoaPrefeitura { get; set; }
        public bool TrocaEndereco { get; set; }

        public PessoaPrefeituraDocumento()
        {

        }

        public PessoaPrefeituraDocumento(int id, int pessoaPrefeituraId, string nome, decimal tamanho, string tipo) : this()
        {
            Id = id;
            PessoaPrefeituraId = pessoaPrefeituraId;
            Nome = nome;
            Tamanho = tamanho;
            Tipo = tipo;
        }
    }
}
