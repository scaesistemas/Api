using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("tipocomposicao", Schema = "orcamentoobras")]
    public class TipoComposicao : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Sigla { get; set; }

        public TipoComposicao()
        {
            
        }

        public TipoComposicao(string nome, int sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }
    }
}
