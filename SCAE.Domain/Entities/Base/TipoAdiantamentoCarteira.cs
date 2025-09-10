using SCAE.Domain.Interfaces.Shared;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SCAE.Domain.Entities.Base
{
    [Table("tipoadiantamentocarteira", Schema = "base")]
    public class TipoAdiantamentoCarteira : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoAdiantamentoCarteira SplitPagamento => new TipoAdiantamentoCarteira(1, "Split de pagamento");


        public TipoAdiantamentoCarteira(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoAdiantamentoCarteira[] ObterDados()
        {
            return new TipoAdiantamentoCarteira[]
            {
                SplitPagamento

            };
        }

        public static TipoAdiantamentoCarteira Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }

        public static TipoAdiantamentoCarteira ObterPorNome(string tipo)
        {
            if (string.IsNullOrEmpty(tipo))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == tipo.ToUpper());
        }
    }

    //Classe feita para usar comparar em expressão com Linq
    public class ComparadorTipoAdiantamentoCarteira : IEqualityComparer<TipoAdiantamentoCarteira>
    {
        public bool Equals(TipoAdiantamentoCarteira x, TipoAdiantamentoCarteira y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] TipoAdiantamentoCarteira obj)
        {
            return obj.Id;
        }
    }
}
