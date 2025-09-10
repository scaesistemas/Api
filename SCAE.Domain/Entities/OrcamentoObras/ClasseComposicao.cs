using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("classecomposicao", Schema = "orcamentoobras")]
    public class ClasseComposicao : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public ClasseComposicao()
        {
                
        }

        public ClasseComposicao(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }
    }
}
