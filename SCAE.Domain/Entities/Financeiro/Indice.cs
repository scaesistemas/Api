using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("indice", Schema = "financeiro")]
    public class Indice : IEntity
    {
        public int Id { get; set; }
        public int TipoIndiceId { get; set; }
        public TipoIndice TipoIndice { get; set; }
        public int CodigoLigacao { get; set; }
        public byte Dia { get; set; }
        public byte Mes { get; set; }
        public ushort Ano { get; set; }
        public decimal Percentual { get; set; }
        public decimal Mensal { get; set; }
        public decimal AvulsoMensal { get; set; }
        public decimal Acumulado { get; set; }
        public bool Executado { get; set; }
        public bool AplicarIndiceNegativo { get; set; } 

        public decimal Total => Percentual + Acumulado;
        public decimal TotalMensal => AvulsoMensal + Mensal;


        public Indice()
        {
            Executado = false;
        }
    }
}
