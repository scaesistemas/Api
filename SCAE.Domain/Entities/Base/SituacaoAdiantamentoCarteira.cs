using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SCAE.Domain.Entities.Base
{
    [Table("situacaoadiantamentocarteira", Schema = "base")]
    public class SituacaoAdiantamentoCarteira : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static SituacaoAdiantamentoCarteira Pendente => new SituacaoAdiantamentoCarteira(1, "Pendente de aprovação");
        [NotMapped] public static SituacaoAdiantamentoCarteira Aprovado => new SituacaoAdiantamentoCarteira(2, "Aprovado");
        [NotMapped] public static SituacaoAdiantamentoCarteira Negado => new SituacaoAdiantamentoCarteira(3, "Negado");
        [NotMapped] public static SituacaoAdiantamentoCarteira Cancelado => new SituacaoAdiantamentoCarteira(4, "Cancelado");
        [NotMapped] public static SituacaoAdiantamentoCarteira Finalizado => new SituacaoAdiantamentoCarteira(5, "Finalizado");



        public SituacaoAdiantamentoCarteira(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static SituacaoAdiantamentoCarteira[] ObterDados()
        {
            return new SituacaoAdiantamentoCarteira[]
            {
                Pendente,
                Aprovado,
                Negado,
                Cancelado,
                Finalizado
            };
        }

        public static SituacaoAdiantamentoCarteira Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }

        public static SituacaoAdiantamentoCarteira ObterPorNome(string situacao)
        {
            if (string.IsNullOrEmpty(situacao))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == situacao.ToUpper());
        }
    }

    //Classe feita para usar comparar em expressão com Linq
    public class ComparadorSituacaoAdiantamentoCarteira : IEqualityComparer<SituacaoAdiantamentoCarteira>
    {
        public bool Equals(SituacaoAdiantamentoCarteira x, SituacaoAdiantamentoCarteira y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] SituacaoAdiantamentoCarteira obj)
        {
            return obj.Id;
        }
    }

}
