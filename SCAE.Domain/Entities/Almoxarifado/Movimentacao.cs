using SCAE.Domain.Entities.Compras;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Projeto;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Almoxarifado
{
    [Table("movimentacao", Schema = "almoxarifado")]
    public class Movimentacao : IEntity
    {
        public int Id { get; set; }
        public int? EmpreendimentoConsumidorId { get; set; }
        public Empreendimento.Empreendimento EmpreendimentoConsumidor { get; set; }
        public int? PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int? EtapaId { get; set; }
        public Etapa Etapa { get; set; }
        public int AlmoxarifadoItemId { get; set; }
        public AlmoxarifadoItem AlmoxarifadoItem { get; set; }
        public int TipoId { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public int TipoOrigemId { get; set; }
        public TipoOrigem TipoOrigem { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Custo { get; set; } //Custo médio
        public decimal Valor { get; set; } //valor original de entrada do produto.
        public DateTime DataHora { get; set; }
        [Required] public string Descricao { get; set; }
        public decimal Total => Quantidade * Custo;

        [NotMapped] public int AlmoxarifadoId { get; set; }
        [NotMapped] public int ProdutoId { get; set; }

        public Movimentacao()
        {
            DataHora = DateTime.Now;
            TipoOrigemId = TipoOrigem.Manual.Id;
        }
    }
}
