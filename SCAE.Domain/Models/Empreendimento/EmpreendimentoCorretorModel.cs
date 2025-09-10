using SCAE.Domain.Interfaces.Shared;

namespace SCAE.Domain.Models.Empreendimento
{
    public class EmpreendimentoCorretorModel : IEntity
    {
        public int Id { get; set; }
        public int QtdeUnidadesDisponiveis { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string Foto { get; set; }

    }
}
