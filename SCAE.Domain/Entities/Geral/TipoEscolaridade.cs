using Microsoft.IdentityModel.Tokens;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Geral
{
    [Table("tipoescolaridade", Schema = "geral")]
    public class TipoEscolaridade : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoEscolaridade FundamentaImcompleto => new TipoEscolaridade(1, "Fundamental - Incompleto");
        [NotMapped] public static TipoEscolaridade FundamentalCompleto => new TipoEscolaridade(2, "Fundamental - Completo");
        [NotMapped] public static TipoEscolaridade MedioIncompleto => new TipoEscolaridade(3, "Médio - Incompleto");
        [NotMapped] public static TipoEscolaridade MedioCompleto => new TipoEscolaridade(4, "Médio - Completo");
        [NotMapped] public static TipoEscolaridade SuperiorIncompleto => new TipoEscolaridade(5, "Superior - Incompleto");
        [NotMapped] public static TipoEscolaridade SuperiorCompleto => new TipoEscolaridade(6, "Superior - Completo");
        [NotMapped] public static TipoEscolaridade Mestrado => new TipoEscolaridade(7, "Mestrado");
        [NotMapped] public static TipoEscolaridade Doutorado => new TipoEscolaridade(8, "Doutorado");
        [NotMapped] public static TipoEscolaridade PosgraduacaoIncompleto => new TipoEscolaridade(9, "Pós-graduação - Incompleto");
        [NotMapped] public static TipoEscolaridade PosgraduacaoCompleto => new TipoEscolaridade(10, "Pós-graduação - Completo");
        [NotMapped] public static TipoEscolaridade SemEscolaridade => new TipoEscolaridade(11, "Sem Escolaridade");


        public TipoEscolaridade(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoEscolaridade[] ObterDados()
        {
            return new TipoEscolaridade[]
            {
                 FundamentaImcompleto,
                 FundamentalCompleto,
                 MedioIncompleto,
                 MedioCompleto,
                 SuperiorIncompleto,
                 SuperiorCompleto,
                 SemEscolaridade,
                 Mestrado,
                 Doutorado,
                 PosgraduacaoIncompleto,
                 PosgraduacaoCompleto
            };
        }

        public static TipoEscolaridade ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
        public static TipoEscolaridade ObterPorId(int id)
        {
            if (id == null)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }
    }
}
