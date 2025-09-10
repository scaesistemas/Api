using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("tipoinsumo", Schema = "orcamentoobras")]
    public class TipoInsumo : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoInsumo Administracao => new (1, "Administração");
        [NotMapped] public static TipoInsumo Aluguel => new (2, "Aluguel");
        [NotMapped] public static TipoInsumo Equipamento => new (3, "Equipamento");
        [NotMapped] public static TipoInsumo EquipamentoAquisicaoPermanente => new (4, "Equipamento para Aquisição Permanente");
        [NotMapped] public static TipoInsumo MaoObra => new (5, "Mão de Obra");
        [NotMapped] public static TipoInsumo Material => new (6, "Material");
        [NotMapped] public static TipoInsumo Outros => new (7, "Outros");
        [NotMapped] public static TipoInsumo Servicos => new (8, "Serviços");
        [NotMapped] public static TipoInsumo Taxas => new (9, "Taxas");
        [NotMapped] public static TipoInsumo Verba => new (10, "Verba");

        public TipoInsumo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoInsumo[] ObterDados()
        {
            return new TipoInsumo[]
            {
                Administracao,
                Aluguel,
                Equipamento,
                EquipamentoAquisicaoPermanente,
                MaoObra,
                Material,
                Outros,
                Servicos,
                Taxas,
                Verba
            };
        }

    }
}
