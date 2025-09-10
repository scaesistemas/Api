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
    [Table("tipocoletalixo", Schema = "geral")]
    public class TipoColetaLixo : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoColetaLixo CeuAberto => new TipoColetaLixo(1, "Céu Aberto");
        [NotMapped] public static TipoColetaLixo Coletado => new TipoColetaLixo(2, "Coletado");
        [NotMapped] public static TipoColetaLixo Enterrado => new TipoColetaLixo(3, "Enterrado");
        [NotMapped] public static TipoColetaLixo Queimado => new TipoColetaLixo(4, "Queimado");
        [NotMapped] public static TipoColetaLixo NaoPossui => new TipoColetaLixo(5, "Não Possui");
        [NotMapped] public static TipoColetaLixo DescartadoTerreno => new TipoColetaLixo(6, "Lixo descartado em terreno ou áreas vizinhas");
        [NotMapped] public static TipoColetaLixo ColetaIrregular => new TipoColetaLixo(6, "Coleta irregular (comercial)");
        [NotMapped] public static TipoColetaLixo ColetaRegular => new TipoColetaLixo(6, "Coleta regular (pública)");
        [NotMapped] public static TipoColetaLixo Outro => new TipoColetaLixo(9, "Outro");


        public TipoColetaLixo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoColetaLixo[] ObterDados()
        {
            return new TipoColetaLixo[]
            {
                 CeuAberto,
                 Coletado,
                 Enterrado,
                 Queimado,
                 NaoPossui,
                 Outro

            };
        }

        public static TipoColetaLixo ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
        public static TipoColetaLixo ObterPorId(int id)
        {
            if (id == null)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }
    }
}
