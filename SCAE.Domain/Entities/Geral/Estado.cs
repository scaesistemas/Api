using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Geral
{
    [Table("estado", Schema = "geral")]
    public class Estado : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required]public string Nome { get; set; }
        [StringLength(02), Required] public string Uf { get; set; }
        [NotMapped] public static Estado EX => new Estado(0, "Exterior", "EX");
        [NotMapped] public static Estado RO => new Estado(11, "Rondônia", "RO");
        [NotMapped] public static Estado AC => new Estado(12, "Acre", "AC");
        [NotMapped] public static Estado AM => new Estado(13, "Amazonas", "AM");
        [NotMapped] public static Estado RR => new Estado(14, "Roraima", "RR");
        [NotMapped] public static Estado PA => new Estado(15, "Pará", "PA");
        [NotMapped] public static Estado AP => new Estado(16, "Amapá", "AP");
        [NotMapped] public static Estado TO => new Estado(17, "Tocantins", "TO");
        [NotMapped] public static Estado MA => new Estado(21, "Maranhão", "MA");
        [NotMapped] public static Estado PI => new Estado(22, "Piauí", "PI");
        [NotMapped] public static Estado CE => new Estado(23, "Ceará", "CE");
        [NotMapped] public static Estado RN => new Estado(24, "Rio Grande do Norte", "RN");
        [NotMapped] public static Estado PB => new Estado(25, "Paraíba", "PB");
        [NotMapped] public static Estado PE => new Estado(26, "Pernambuco", "PE");
        [NotMapped] public static Estado AL => new Estado(27, "Alagoas", "AL");
        [NotMapped] public static Estado SE => new Estado(28, "Sergipe", "SE");
        [NotMapped] public static Estado BA => new Estado(29, "Bahia", "BA");
        [NotMapped] public static Estado MG => new Estado(31, "Minas Gerais", "MG");
        [NotMapped] public static Estado ES => new Estado(32, "Espírito Santo", "ES");
        [NotMapped] public static Estado RJ => new Estado(33, "Rio de Janeiro", "RJ");
        [NotMapped] public static Estado SP => new Estado(35, "São Paulo", "SP");
        [NotMapped] public static Estado PR => new Estado(41, "Paraná", "PR");
        [NotMapped] public static Estado SC => new Estado(42, "Santa Catarina", "SC");
        [NotMapped] public static Estado RS => new Estado(43, "Rio Grande do Sul", "RS");
        [NotMapped] public static Estado MS => new Estado(50, "Mato Grosso do Sul", "MS");
        [NotMapped] public static Estado MT => new Estado(51, "Mato Grosso", "MT");
        [NotMapped] public static Estado GO => new Estado(52, "Goiás", "GO");
        [NotMapped] public static Estado DF => new Estado(53, "Distrito Federal", "DF");

        public Estado(int id, string nome, string uf)
        {
            Id = id;
            Nome = nome;
            Uf = uf;
        }

        public static Estado[] ObterDados()
        {
            return new Estado[]
            {
                EX,
                RO,
                AC,
                AM,
                RR,
                PA,
                AP,
                TO,
                MA,
                PI,
                CE,
                RN,
                PB,
                PE,
                AL,
                SE,
                BA,
                MG,
                ES,
                RJ,
                SP,
                PR,
                SC,
                RS,
                MS,
                MT,
                GO,
                DF
            };
        }

        public static Estado ObterPorUf(string uf)
        {
            if (string.IsNullOrEmpty(uf))
                return null;

            return ObterDados().SingleOrDefault(x => x.Uf == uf.ToUpper());
        }

        public static Estado ObterPorNome(string nome) 
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
    }
}
