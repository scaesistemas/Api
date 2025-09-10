using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Shared;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("lote", Schema = "empreendimento")]
    public class Lote : IEntity
    {
        public int Id { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
        public DimensaoLote Dimensao { get; set; }
        [Required] public InfraestruturaLote Infraestrutura { get; set; }
        public LegalizacaoLote Legalizacao { get; set; }
        public ConfrontanteLote Confrontante { get; set; }
        public ICollection<LadoAdicional> LadosAdicionais { get; set; }


        public Lote()
        {
            LadosAdicionais = new List<LadoAdicional>();
            Infraestrutura = new InfraestruturaLote();
        }
    }

    [Owned]
    public class ConfrontanteLote
    {
        public decimal Frente { get; set; }
        public decimal Fundo { get; set; }
        public decimal LadoEsquerdo { get; set; }
        public decimal LadoDireito { get; set; }
        
    }
    public class InfraestruturaLote
    {
        public InfraestruturaLazer Lazer { get; set; }
        public string Observacao { get; set; }

        public InfraestruturaLote()
        {
            Lazer = new InfraestruturaLazer();
            Observacao = "";
        }
    }

    [Owned]
    public class DimensaoLote
    {
        public decimal Frente { get; set; }
        public decimal Fundo { get; set; }
        public decimal LadoEsquerdo { get; set; }
        public decimal LadoDireito { get; set; }
        public decimal Curva { get; set; }
        public decimal AreaTotal { get; set; }

    }

    public class LegalizacaoLote : Legalizacao
    {

    }
}
