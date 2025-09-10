using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("tipodespesa", Schema = "financeiro")]
    public class TipoDespesa : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        [NotMapped] public static TipoDespesa Titulo => new TipoDespesa(1, "Título");
        [NotMapped] public static TipoDespesa TituloCredito => new TipoDespesa(2, "Título de Crédito");
        [NotMapped] public static TipoDespesa TituloRecorrente => new TipoDespesa(3, "Título Recorrente");

        public TipoDespesa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoDespesa[] ObterDados()
        {
            return new TipoDespesa[]
            {
                Titulo,
                TituloCredito,
                TituloRecorrente
            };
        }
    }
}
