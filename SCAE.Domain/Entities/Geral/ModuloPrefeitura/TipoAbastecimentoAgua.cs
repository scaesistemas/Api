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
    [Table("tipoabastecimentoagua", Schema = "geral")]
    public class TipoAbastecimentoAgua : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoAbastecimentoAgua CarroPipa => new TipoAbastecimentoAgua(1, "Carro Pipa");
        [NotMapped] public static TipoAbastecimentoAgua Cisterna => new TipoAbastecimentoAgua(2, "Cisterna");
        [NotMapped] public static TipoAbastecimentoAgua NaoPossui => new TipoAbastecimentoAgua(3, "Não Possui");
        [NotMapped] public static TipoAbastecimentoAgua PocoNascente => new TipoAbastecimentoAgua(4, "Poço/Nascente");
        [NotMapped] public static TipoAbastecimentoAgua RedePublica => new TipoAbastecimentoAgua(5, "Rede Pública");
        [NotMapped] public static TipoAbastecimentoAgua Outra => new TipoAbastecimentoAgua(6, "Outra");


        public TipoAbastecimentoAgua(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoAbastecimentoAgua[] ObterDados()
        {
            return new TipoAbastecimentoAgua[]
            {
                 CarroPipa,
                 Cisterna,
                 NaoPossui,
                 PocoNascente,
                 RedePublica,
                 Outra
            };
        }

        public static TipoAbastecimentoAgua ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
        public static TipoAbastecimentoAgua ObterPorId(int id)
        {
            if (id == null)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }
    }
}
