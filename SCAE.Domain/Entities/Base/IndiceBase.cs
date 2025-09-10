using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Base
{
    [Table("indice", Schema = "base")]
    public class IndiceBase : IEntity
    {
        public int Id { get; set; }
        public int TipoIndiceId { get; set; }
        public TipoIndiceBase TipoIndice { get; set; }
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


        public IndiceBase()
        {
            Executado = false;
            CodigoLigacao = GerarCodigoUnico();
        }

        private static int GerarCodigoUnico()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
