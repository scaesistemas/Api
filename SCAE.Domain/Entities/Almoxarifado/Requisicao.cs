using SCAE.Domain.Entities.Compras;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Almoxarifado
{
    
    [Table("requisicao", Schema = "almoxarifado")]
    public class Requisicao : IEntity
    {
        public int Id { get; set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento.Empreendimento Empreendimento { get; private set; }
        public DateTime Data { get; set; }
        public string Solicitante { get; set; }
        [Required] public string Descricao { get; set; }
        public int AlmoxarifadoId { get; set; }
        public Almoxarifado Almoxarifado { get; private set; }
        public int? PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public DateTime? DataHoraExecucao { get; set; }
        public bool Executada { get; set; }
        public ICollection<RequisicaoItem> Itens { get; set; }
        [MaxLength(60)] public string Titulo { get; set; }

        public Requisicao()
        {
            Data = DateTime.Now;
            Executada = false;
            Itens = new List<RequisicaoItem>();
        }
    }
}
