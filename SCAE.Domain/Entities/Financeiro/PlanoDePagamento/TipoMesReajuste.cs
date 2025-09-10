using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro.PlanoDePagamento
{
    [Table("tipomesreajuste", Schema = "financeiro")]
    public class TipoMesReajuste : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [NotMapped] public static TipoMesReajuste MesContrato => new(1, "Mês do Contrato");
        [NotMapped] public static TipoMesReajuste PrimeiraParcelaEntrada => new(2, "1ª Parcela de Entrada");
        [NotMapped] public static TipoMesReajuste PrimeiraParcelaFinanciamento => new(3, "1ª Parcela do Financiamento");
        [NotMapped] public static TipoMesReajuste UmMesAntesContrato => new(4, "1 Mês Antes do Contrato");
        [NotMapped] public static TipoMesReajuste DoisMesesAntesContrato => new(5, "2 Meses Antes do Contrato");
        [NotMapped] public static TipoMesReajuste TresMesesAntesContrato => new(6, "3 Meses Antes do Contrato");
        [NotMapped] public static TipoMesReajuste UmMesDepoisContrato => new(7, "1 Mês Depois do Contrato");
        [NotMapped] public static TipoMesReajuste DoisMesesDepoisContrato => new(8, "2 Meses Depois do Contrato");
        [NotMapped] public static TipoMesReajuste TresMesesDepoisContrato => new(9, "3 Meses Depois do Contrato");



        public TipoMesReajuste(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoMesReajuste[] ObterDados()
        {
            return new TipoMesReajuste[]
            {
                MesContrato,
                PrimeiraParcelaEntrada,
                PrimeiraParcelaFinanciamento,
                UmMesAntesContrato,
                DoisMesesAntesContrato,
                TresMesesAntesContrato,
                UmMesDepoisContrato,
                DoisMesesDepoisContrato,
                TresMesesDepoisContrato
            };
        }

        public static TipoMesReajuste Obter(int id)
        {
            return ObterDados().FirstOrDefault(x => x.Id == id);
        }
    }
}
