using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAE.Domain.Interfaces.Shared;

namespace SCAE.Domain.Entities.Geral.ModuloPrefeitura
{
    [Table("tipocondicaomoradia", Schema = "geral")]
    public class TipoCondicaoMoradia : IEntity
    {

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoCondicaoMoradia AreaRisco => new TipoCondicaoMoradia(1, "Área de risco");
        [NotMapped] public static TipoCondicaoMoradia Boa => new TipoCondicaoMoradia(2, "Boa (estruturalmente estável)");
        [NotMapped] public static TipoCondicaoMoradia Precaria => new TipoCondicaoMoradia(3, "Precária");
        [NotMapped] public static TipoCondicaoMoradia Regular => new TipoCondicaoMoradia(4, "Regular (necessita de pequenas melhorias)");
        [NotMapped] public static TipoCondicaoMoradia Outra => new TipoCondicaoMoradia(5, "Outro");


        public TipoCondicaoMoradia(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoCondicaoMoradia[] ObterDados()
        {
            return new TipoCondicaoMoradia[]
            {
                 AreaRisco,
                 Boa,
                 Precaria,
                 Regular,
                 Outra
            };
        }

        public static TipoCondicaoMoradia ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
        public static TipoCondicaoMoradia ObterPorId(int id)
        {
            if (id == null)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }
    }
}
