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
    [Table("tipoenergiamoradia", Schema = "geral")]
    public class TipoEnergiaMoradia : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoEnergiaMoradia RelogioComunitario => new TipoEnergiaMoradia(1, "Relógio Comunitário");
        [NotMapped] public static TipoEnergiaMoradia RelogioProprio => new TipoEnergiaMoradia(2, "Relógio Próprio");
        [NotMapped] public static TipoEnergiaMoradia SemEnergiaEletrica => new TipoEnergiaMoradia(3, "Sem Energia Elétrica");
        [NotMapped] public static TipoEnergiaMoradia SemRelogio => new TipoEnergiaMoradia(4, "Sem Relógio");
        [NotMapped] public static TipoEnergiaMoradia GeradorCombustivel => new TipoEnergiaMoradia(5, "Gerador movido a combustível");
        [NotMapped] public static TipoEnergiaMoradia GeracaoPropria => new TipoEnergiaMoradia(6, "Geração própria (energia solar, eólica)");
        [NotMapped] public static TipoEnergiaMoradia RedePublica => new TipoEnergiaMoradia(7, "Rede Pública");
        [NotMapped] public static TipoEnergiaMoradia Outro => new TipoEnergiaMoradia(8, "Outro");


        public TipoEnergiaMoradia(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoEnergiaMoradia[] ObterDados()
        {
            return new TipoEnergiaMoradia[]
            {
                 RelogioComunitario,
                 RelogioProprio,
                 SemEnergiaEletrica,
                 SemRelogio,
                 GeradorCombustivel,
                 RedePublica,
                 GeracaoPropria,
                 Outro
            };
        }

        public static TipoEnergiaMoradia ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
        public static TipoEnergiaMoradia ObterPorId(int id)
        {
            if (id == null)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }
    }
}
