using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("tipoempreendimento", Schema = "empreendimento")]
    public class TipoEmpreendimento : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(25), Required] public string Nome { get; set; }

        [NotMapped] public static TipoEmpreendimento Loteamento => new TipoEmpreendimento(1, "Loteamento");
        [NotMapped] public static TipoEmpreendimento PredioTorre => new TipoEmpreendimento(2, "Prédio/Torre");
        [NotMapped] public static TipoEmpreendimento CondominioConjuntodido => new TipoEmpreendimento(3, "Condomínio/Conjunto");
        [NotMapped] public static TipoEmpreendimento Cemiterio => new TipoEmpreendimento(4, "Cemitério");

        public TipoEmpreendimento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoEmpreendimento[] ObterDados()
        {
            return new TipoEmpreendimento[]
            {
                Loteamento,
                PredioTorre,
                CondominioConjuntodido,
                Cemiterio
            };
        }

        public static TipoEmpreendimento ObterPorNome(string tipoEmpreendimento)
        {
            if (string.IsNullOrEmpty(tipoEmpreendimento))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == tipoEmpreendimento.ToUpper());
        }
    }
}
