using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Geral
{
    [Table("nacionalidade", Schema = "geral")]
    public class Nacionalidade : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static Nacionalidade Brasileiro => new Nacionalidade(10, "Brasileiro");
        [NotMapped] public static Nacionalidade NaturalizadoBrasileiro => new Nacionalidade(20, "Naturalizado Brasileiro");
        [NotMapped] public static Nacionalidade Argentino => new Nacionalidade(21, "Argentino");
        [NotMapped] public static Nacionalidade Boliviano => new Nacionalidade(22, "Boliviano");
        [NotMapped] public static Nacionalidade Chileno => new Nacionalidade(23, "Chileno");
        [NotMapped] public static Nacionalidade Paraguaio => new Nacionalidade(24, "Paraguaio");
        [NotMapped] public static Nacionalidade Uruguaio => new Nacionalidade(25, "Uruguaio");
        [NotMapped] public static Nacionalidade Alemao => new Nacionalidade(30, "Alemão");
        [NotMapped] public static Nacionalidade Belga => new Nacionalidade(31, "Belga");
        [NotMapped] public static Nacionalidade Britanico => new Nacionalidade(32, "Britânico");
        [NotMapped] public static Nacionalidade Canadense => new Nacionalidade(34, "Canadense");
        [NotMapped] public static Nacionalidade Espanhol => new Nacionalidade(35, "Espanhol");
        [NotMapped] public static Nacionalidade NorteAmericanoEua => new Nacionalidade(36, "Norte-Americano (EUA)");
        [NotMapped] public static Nacionalidade Frances => new Nacionalidade(37, "Francês");
        [NotMapped] public static Nacionalidade Suico => new Nacionalidade(38, "Suíço");
        [NotMapped] public static Nacionalidade Italiano => new Nacionalidade(39, "Italiano");
        [NotMapped] public static Nacionalidade Japones => new Nacionalidade(41, "Japonês");
        [NotMapped] public static Nacionalidade Chines => new Nacionalidade(42, "Chinês");
        [NotMapped] public static Nacionalidade Coreano => new Nacionalidade(43, "Coreano");
        [NotMapped] public static Nacionalidade Portugues => new Nacionalidade(45, "Português");
        [NotMapped] public static Nacionalidade OutrosLatinoAmericanos => new Nacionalidade(48, "Outros Latino-Americanos");
        [NotMapped] public static Nacionalidade OutrosAsiaticos => new Nacionalidade(49, "Outros Asiáticos");
        [NotMapped] public static Nacionalidade Outros => new Nacionalidade(50, "Outros");


        public Nacionalidade(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static Nacionalidade[] ObterDados()
        {
            return new Nacionalidade[]
            {
                Brasileiro,
                Argentino,
                NaturalizadoBrasileiro,
                Boliviano,
                Chileno,
                Paraguaio,
                Uruguaio,
                Alemao,
                Belga,
                Britanico,
                Canadense,
                Espanhol,
                NorteAmericanoEua,
                Frances,
                Suico,
                Italiano,
                Japones,
                Chines,
                Coreano,
                Portugues,
                OutrosLatinoAmericanos,
                OutrosAsiaticos,
                Outros
            };
        }

        public static Nacionalidade ObterPorNome(string nacionalidade)
        {
            if (string.IsNullOrEmpty(nacionalidade))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nacionalidade.ToUpper());
        }
        public static Nacionalidade ObterPorId(int id)
        {
            if (id < 0)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }

    }
}
