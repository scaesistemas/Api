using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Geral.ModuloPrefeitura
{
    [Table("tipomoradia", Schema = "geral")]
    public class TipoMoradia : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoMoradia Aluguel => new TipoMoradia(1, "Aluguel");
        [NotMapped] public static TipoMoradia Cedida => new TipoMoradia(2, "Cedida");
        [NotMapped] public static TipoMoradia Emprestada => new TipoMoradia(3, "Emprestada");
        [NotMapped] public static TipoMoradia Invadida => new TipoMoradia(4, "Invadida");
        [NotMapped] public static TipoMoradia MoraComAmigos => new TipoMoradia(5, "Mora com Amigos");
        [NotMapped] public static TipoMoradia MoraComParentes => new TipoMoradia(6, "Mora com Parentes");
        [NotMapped] public static TipoMoradia MoraInstituicaoBeneficiente => new TipoMoradia(7, "Mora em Instituições Beneficientes");
        [NotMapped] public static TipoMoradia OcupacaoIrregular => new TipoMoradia(8, "Ocupação irregular");
        [NotMapped] public static TipoMoradia Propria => new TipoMoradia(9, "Própria");
        [NotMapped] public static TipoMoradia PropriaFinanciada => new TipoMoradia(10, "Própria financiada");
        [NotMapped] public static TipoMoradia PropriaQuitada => new TipoMoradia(11, "Própria quitada");
        [NotMapped] public static TipoMoradia Reurb => new TipoMoradia(12, "Em processo de regularização fundiária (Reurb)");
        [NotMapped] public static TipoMoradia Heranca => new TipoMoradia(13, "Herança");
        [NotMapped] public static TipoMoradia SemMoradiaFixa => new TipoMoradia(14, "Sem Moradia Fixa");
        [NotMapped] public static TipoMoradia Outra => new TipoMoradia(15, "Outra");


        public TipoMoradia(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoMoradia[] ObterDados()
        {
            return new TipoMoradia[]
            {
                 Aluguel,
                 Cedida,
                 Emprestada,
                 Invadida,
                 MoraComAmigos,
                 MoraComParentes,
                 MoraInstituicaoBeneficiente,
                 OcupacaoIrregular,
                 Propria,
                 PropriaFinanciada,
                 PropriaQuitada,
                 Reurb,
                 Heranca,
                 SemMoradiaFixa,
                 Outra
            };
        }

        public static TipoMoradia ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
        public static TipoMoradia ObterPorId(int id)
        {
            if (id == null)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }
    }
}
