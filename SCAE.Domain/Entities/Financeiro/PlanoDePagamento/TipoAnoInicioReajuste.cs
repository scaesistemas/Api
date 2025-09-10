using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Financeiro.PlanoDePagamento
{
    [Table("tipoanoinicioreajuste", Schema = "financeiro")]
    public class TipoAnoInicioReajuste : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoAnoInicioReajuste AnoContrato => new(1, "Ano do contrato");
        [NotMapped] public static TipoAnoInicioReajuste UmAnoAposContrato => new(2, "1 ano após o contrato");
        [NotMapped] public static TipoAnoInicioReajuste DoisAnosAposContrato => new(3, "2 anos após o contrato");
        [NotMapped] public static TipoAnoInicioReajuste TresAnosAposContrato => new(4, "3 anos após o contrato");



        public TipoAnoInicioReajuste(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoAnoInicioReajuste[] ObterDados()
        {
            return new TipoAnoInicioReajuste[]
            {
                AnoContrato,
                UmAnoAposContrato,
                DoisAnosAposContrato,
                TresAnosAposContrato
            };
        }

        public static TipoAnoInicioReajuste Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }
    }
}
