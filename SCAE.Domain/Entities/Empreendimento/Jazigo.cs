using SCAE.Domain.Interfaces.Shared;

namespace SCAE.Domain.Entities.Empreendimento
{
    public class Jazigo : IEntity
    {
        public int Id { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
    }
}
