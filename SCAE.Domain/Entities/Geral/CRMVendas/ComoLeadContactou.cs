using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using SCAE.Framework.Helper;

namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("comoleadcontactou", Schema = "geral")]
    public class ComoLeadContactou : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(60), Required] public string Nome { get; set; }

        [NotMapped] public static ComoLeadContactou NaoInformadoVendedor => new(1, "Não informado pelo vendedor");
        [NotMapped] public static ComoLeadContactou WhatsApp => new(2, "Whatsapp");
        [NotMapped] public static ComoLeadContactou Telefone => new(3, "Telefone");
        [NotMapped] public static ComoLeadContactou VisitaNaSede => new(4, "Visita na sede");
        [NotMapped] public static ComoLeadContactou RedeSocial => new(5, "Rede social");
        [NotMapped] public static ComoLeadContactou Corretores => new(6, "Corretores");
        [NotMapped] public static ComoLeadContactou Imobiliaria => new(7, "Imobiliária");
        [NotMapped] public static ComoLeadContactou Email => new(8, "Email");
        [NotMapped] public static ComoLeadContactou Site => new(9, "Site");
        [NotMapped] public static ComoLeadContactou PlantaoVendas => new(10, "Plantão de vendas");
        [NotMapped] public static ComoLeadContactou Outros => new(11, "Outros");


        public ComoLeadContactou()
        {

        }
        public ComoLeadContactou(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static ComoLeadContactou[] ObterDados()
        {
            return new ComoLeadContactou[]
            {
                NaoInformadoVendedor,
                WhatsApp,
                Telefone,
                VisitaNaSede,
                RedeSocial,
                Corretores,
                Imobiliaria,
                Email,
                Site,
                PlantaoVendas,
                Outros
            };
        }

        public static List<ComoLeadContactou> ObterDadosOrdenados()
        {
            return ObterDados()
                    .OrderBy(x => TreeViewHelper.PadNumbers(x.Nome)).ToList();
        }


    }
}
