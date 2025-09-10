using SCAE.Domain.Entities.Shared;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral.ModuloPrefeitura
{
    [Table("pessoaprefeituracontato", Schema = "geral")]
    public class PessoaPrefeituraContato : Contato, IEntity
    {
        public int Id { get; set; }
        public int PessoaPrefeituraId { get; set; }
        public PessoaPrefeitura PessoaPrefeitura { get; set; }
    }
}
