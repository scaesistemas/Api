using SCAE.Domain.Interfaces.Shared;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using SCAE.Framework.Helper;

namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("comoleadnosencontrou", Schema = "geral")]
    public class ComoLeadNosEncontrou : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(60), Required] public string Nome { get; set; }

        [NotMapped] public static ComoLeadNosEncontrou NaoInformadoVendedor => new(1, "Não informado pelo vendedor");
        [NotMapped] public static ComoLeadNosEncontrou OutdoorForaEmpreendimento => new(2, "Outdoor fora do empreendimento");
        [NotMapped] public static ComoLeadNosEncontrou Radio => new(3, "Rádio");
        [NotMapped] public static ComoLeadNosEncontrou OutdoorPlacaFaixaEmpreendimento => new(4, "Outdoor / Placa / Faixa no Empreendimento");
        [NotMapped] public static ComoLeadNosEncontrou FaixaHorizontalForaEmpreendimento => new(5, "Faixa horizontal fora do empreendimento");
        [NotMapped] public static ComoLeadNosEncontrou IndicacaoTerceiros => new(6, "Indicação de terceiros");
        [NotMapped] public static ComoLeadNosEncontrou JornalRevistaMalaDiretaImpressa => new(7, "Jornais / Revistas / Mala Direta Impressa");
        [NotMapped] public static ComoLeadNosEncontrou PlantaoVendas => new(8, "Plantão de vendas");
        [NotMapped] public static ComoLeadNosEncontrou Eventos => new(9, "Eventos");
        [NotMapped] public static ComoLeadNosEncontrou PropagandaVolanteSonora => new(10, "Propaganda volante (sonora)");
        [NotMapped] public static ComoLeadNosEncontrou PropagandaFlyerFolders => new(11, "Propaganda (Flyer e folders)");
        [NotMapped] public static ComoLeadNosEncontrou Site => new(12, "Site");
        [NotMapped] public static ComoLeadNosEncontrou Telemarketing => new(13, "Telemarketing");
        [NotMapped] public static ComoLeadNosEncontrou VisitaEmpreendimento => new(14, "Visita no empreendimento");
        [NotMapped] public static ComoLeadNosEncontrou MalaDiretaDigitalEmail => new(15, "Mala direta digital (E-mail)");
        [NotMapped] public static ComoLeadNosEncontrou Televisao => new(16, "Televisão");
        [NotMapped] public static ComoLeadNosEncontrou Corretores => new(17, "Corretores");
        [NotMapped] public static ComoLeadNosEncontrou Imobiliarias => new(18, "Imobiliárias");
        [NotMapped] public static ComoLeadNosEncontrou Outros => new(19, "Outros");
        [NotMapped] public static ComoLeadNosEncontrou PropagandaSonoraFlyerFolder => new(20, "Propaganda (Sonora, Flyer e Folders)");
        [NotMapped] public static ComoLeadNosEncontrou MarketingDigital => new(21, "Marketing Digital");
        [NotMapped] public static ComoLeadNosEncontrou Facebook => new(22, "Facebook");
        [NotMapped] public static ComoLeadNosEncontrou TwitterX => new(23, "Twitter (X)");
        [NotMapped] public static ComoLeadNosEncontrou Instagram => new(24, "Instagram");
        [NotMapped] public static ComoLeadNosEncontrou Youtube => new(25, "Youtube");
        [NotMapped] public static ComoLeadNosEncontrou TikTok => new(26, "TikTok");
        [NotMapped] public static ComoLeadNosEncontrou Linkedin => new(27, "Linkedin");
        [NotMapped] public static ComoLeadNosEncontrou GoogleAds => new(28, "GoogleAds");






        public ComoLeadNosEncontrou()
        {

        }
        public ComoLeadNosEncontrou(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static ComoLeadNosEncontrou[] ObterDados()
        {
            return new ComoLeadNosEncontrou[]
            {
                NaoInformadoVendedor,
                OutdoorForaEmpreendimento,
                Radio,
                OutdoorPlacaFaixaEmpreendimento,
                FaixaHorizontalForaEmpreendimento,
                IndicacaoTerceiros,
                JornalRevistaMalaDiretaImpressa,
                PlantaoVendas,
                Eventos,
                PropagandaVolanteSonora,
                PropagandaFlyerFolders,
                Site,
                Telemarketing,
                VisitaEmpreendimento,
                MalaDiretaDigitalEmail,
                Televisao,
                Corretores,
                Imobiliarias,
                Outros,
                PropagandaSonoraFlyerFolder,
                MarketingDigital,
                Facebook,
                TwitterX,
                Instagram,
                Youtube,
                TikTok,
                Linkedin,
                GoogleAds
            };
        }

        public static List<ComoLeadNosEncontrou> ObterDadosOrdenados()
        {
            return ObterDados()
                    .OrderBy(x => TreeViewHelper.PadNumbers(x.Nome)).ToList();
        }


    }
}
