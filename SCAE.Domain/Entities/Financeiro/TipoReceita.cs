using SCAE.Domain.Interfaces.Shared;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("tiporeceita", Schema = "financeiro")]
    public class TipoReceita : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } 
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoReceita Titulo => new TipoReceita(1, "Financiamento");
        [NotMapped] public static TipoReceita TituloCredito => new TipoReceita(2, "Crédito");
        [NotMapped] public static TipoReceita TituloEntrada => new TipoReceita(3, "Entrada");
        [NotMapped] public static TipoReceita TituloHonorarios => new TipoReceita(4, "Honorários");
        [NotMapped] public static TipoReceita TituloIntermediaria => new TipoReceita(5, "Intermediária");
        [NotMapped] public static TipoReceita Outros => new TipoReceita(9, "Serviço");

        public TipoReceita(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoReceita[] ObterDados()
        {
            return new TipoReceita[]
            {
                Titulo,
                TituloCredito,
                TituloEntrada,
                TituloHonorarios,
                TituloIntermediaria,
                Outros
            };
        }

        public static TipoReceita Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }

        public static TipoReceita ObterPorNome(string tipo)
        {
            if (string.IsNullOrEmpty(tipo))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == tipo.ToUpper());
        }
    }

    //Classe feita para usar comparar em expressão com Linq
    public class ComparadorTipoReceita : IEqualityComparer<TipoReceita>
    {
        public bool Equals(TipoReceita x, TipoReceita y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] TipoReceita obj)
        {
            return obj.Id;
        }
    }
}
