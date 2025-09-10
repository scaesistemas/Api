using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Geral.ModuloPrefeitura
{
    [Table("tipoesgotamentosanitario", Schema = "geral")]
    public class TipoEsgotamentoSanitario : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoEsgotamentoSanitario FossaRudimentar => new TipoEsgotamentoSanitario(1, "Fossa rudimentar (sumidouro)");
        [NotMapped] public static TipoEsgotamentoSanitario FossaSeptica => new TipoEsgotamentoSanitario(2, "Fossa séptica");
        [NotMapped] public static TipoEsgotamentoSanitario LancamentoRio => new TipoEsgotamentoSanitario(3, "Lançamento direto em rio ou curso d’água");
        [NotMapped] public static TipoEsgotamentoSanitario NaoPossui => new TipoEsgotamentoSanitario(4, "Não possui sistema de esgoto");
        [NotMapped] public static TipoEsgotamentoSanitario RedePublica => new TipoEsgotamentoSanitario(5, "Rede pública de esgoto");
        [NotMapped] public static TipoEsgotamentoSanitario Outra => new TipoEsgotamentoSanitario(6, "Outros");


        public TipoEsgotamentoSanitario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoEsgotamentoSanitario[] ObterDados()
        {
            return new TipoEsgotamentoSanitario[]
            {
                FossaRudimentar,
                FossaSeptica,
                LancamentoRio,
                NaoPossui,
                RedePublica,
                Outra
            };
        }

        public static TipoEsgotamentoSanitario ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
        public static TipoEsgotamentoSanitario ObterPorId(int id)
        {
            if (id == null)
                return null;

            return ObterDados().SingleOrDefault(x => x.Id == id);
        }
    }
}
